namespace ConsoleApplication1
{
    public interface IPointRuleHandler<in TRequest, out TResponse>
        where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    }
}