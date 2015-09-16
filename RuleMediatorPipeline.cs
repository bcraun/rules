namespace ConsoleApplication1
{
    public class RuleMediatorPipeline<TRequest, TResponse>
        : IRuleHandler<TRequest, TResponse>
        where TRequest : IRuleExecutor
    {
        private readonly IRulePreHandler<TRequest>[] _rulePreHandlers;
        private readonly IRuleHandler<TRequest, TResponse> _inner;
        private readonly IRulePostHandler<TRequest, TResponse>[] _rulePostHandlers;

        public RuleMediatorPipeline(
            IRuleHandler<TRequest, TResponse> inner,
            IRulePreHandler<TRequest>[] rulePreHandlers,
            IRulePostHandler<TRequest, TResponse>[] rulePostHandlers
            )
        {
            _inner = inner;
            _rulePreHandlers = rulePreHandlers;
            _rulePostHandlers = rulePostHandlers;
        }

        public TResponse Handle(TRequest message, IRuleContext<double> context)
        {
            foreach (var preRequestHandler in _rulePreHandlers)
            {
                preRequestHandler.Handle(message, context);
            }

            var result = _inner.Handle(message, context);

            foreach (var postRequestHandler in _rulePostHandlers)
            {
                postRequestHandler.Handle(message, context, result);
            }

            return result;
        }
    }
}