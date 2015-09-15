namespace ConsoleApplication1
{
    public class PointRuleMediatorPipeline<TRequest, TResponse>
        : IPointRuleHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IPointRulePreHandler<TRequest>[] _pointRulePreHandlers;
        private readonly IPointRuleHandler<TRequest, TResponse> _inner;
        private readonly IPointRulePostHandler<TRequest, TResponse>[] _pointRulePostHandlers;

        public PointRuleMediatorPipeline(
            IPointRuleHandler<TRequest, TResponse> inner,
            IPointRulePreHandler<TRequest>[] pointRulePreHandlers,
            IPointRulePostHandler<TRequest, TResponse>[] pointRulePostHandlers
            )
        {
            _inner = inner;
            _pointRulePreHandlers = pointRulePreHandlers;
            _pointRulePostHandlers = pointRulePostHandlers;
        }

        public TResponse Handle(TRequest message)
        {
            foreach (var preRequestHandler in _pointRulePreHandlers)
            {
                preRequestHandler.Handle(message);
            }

            var result = _inner.Handle(message);

            foreach (var postRequestHandler in _pointRulePostHandlers)
            {
                postRequestHandler.Handle(message, result);
            }

            return result;
        }
    }
}