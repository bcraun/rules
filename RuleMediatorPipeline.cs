namespace ConsoleApplication1
{
    public class RuleMediatorPipeline<TRequest, TResponse>
        : IRuleHandler<TRequest, TResponse>
        where TRequest : IRuleExecutor
    {
        private readonly IPreRuleHandler<TRequest>[] _preRuleHandlers;
        private readonly IRuleHandler<TRequest, TResponse> _inner;
        private readonly IPostRuleHandler<TRequest, TResponse>[] _postRuleHandlers;

        public RuleMediatorPipeline(
            IRuleHandler<TRequest, TResponse> inner,
            IPreRuleHandler<TRequest>[] preRuleHandlers,
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
                foreach (var preRequestHandler in _preRuleHandlers)
                {
                    preRequestHandler.Handle(executor, context);
                }

                var result = _inner.Handle(executor, context);

                foreach (var postRequestHandler in _postRuleHandlers)
                {
                    postRequestHandler.Handle(executor, context, result);
                }

                return result;
            }
            return default(TResponse);
        }
    }
}