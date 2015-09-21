using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class RuleMediatorPipeline<TRequest, TResponse>
        : IRuleHandler<TRequest, TResponse>
        where TRequest : IRuleExecutor 
        where TResponse : class, new()
    {
        private readonly IPreRuleHandler<TRequest>[] _preRuleHandlers;
        private readonly IRuleHandler<TRequest, TResponse> _inner;
        private readonly IPostRuleHandler<TRequest, TResponse>[] _postRuleHandlers;
        private readonly IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> _serviceBusClient;

        public RuleMediatorPipeline(
            IRuleHandler<TRequest, TResponse> inner,
            IPreRuleHandler<TRequest>[] preRuleHandlers,
            IPostRuleHandler<TRequest, TResponse>[] postRuleHandlers,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient
            )
        {
            _inner = inner;
            _preRuleHandlers = preRuleHandlers;
            _postRuleHandlers = postRuleHandlers;
            _serviceBusClient = serviceBusClient;
        }

        /// <summary>
        /// Handles rule execution pipeline.
        /// </summary>
        /// <param name="executor">The executor.</param>
        /// <param name="context">The context.</param>
        /// <returns>TResponse.</returns>
        /// <remarks>Caller should evaluate return value for null  
        /// since default(TResponse) can be null in some cases.
        /// </remarks>
        public TResponse HandleAsync(
            TRequest executor, 
            IRuleContext context)
        {
            var ctx = (PointRuleContext)context;

            if (ctx.IsEnabled)
            {
                foreach (var preRequestHandler in _preRuleHandlers)
                {
                    preRequestHandler.HandleASync(executor, context);
                }

                TResponse result = _inner.HandleAsync(executor, context);

                foreach (var postRequestHandler in _postRuleHandlers)
                {
                    postRequestHandler.HandleAsync(executor, context, result, _serviceBusClient);
                }

                return result;
            }

            return default(TResponse);
        }
    }
}