namespace ConsoleApplication1
{
    public class RuleMediatorPipeline<TRequest, TResponse>
        : IRuleHandler<TRequest, TResponse>
        where TRequest : IRuleExecutor where TResponse : class, new()
    {
        private readonly IPreRuleHandler<TRequest, TResponse>[] _preRuleHandlers;
        private readonly IRuleHandler<TRequest, TResponse> _inner;
        private readonly IPostRuleHandler<TRequest, TResponse>[] _postRuleHandlers;

        public RuleMediatorPipeline(
            IRuleHandler<TRequest, TResponse> inner,
            IPreRuleHandler<TRequest, TResponse>[] preRuleHandlers,
            IPostRuleHandler<TRequest, TResponse>[] postRuleHandlers
            )
        {
            _inner = inner;
            _preRuleHandlers = preRuleHandlers;
            _postRuleHandlers = postRuleHandlers;
        }

        public TResponse Handle(TRequest executor, IRuleContext<double> context)
        {
            var ctx = (PointRuleContext)context;

            if (ctx.IsEnabled)
            {
                TResponse result;

                foreach (var preRequestHandler in _preRuleHandlers)
                {
                    result = preRequestHandler.Handle(executor, context);
                }

                result = _inner.Handle(executor, context);

                foreach (var postRequestHandler in _postRuleHandlers)
                {
                    result = postRequestHandler.Handle(executor, context, result);
                }

                return result;
            }

            return default(TResponse);
        }
    }
}