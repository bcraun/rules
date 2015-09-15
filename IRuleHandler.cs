namespace ConsoleApplication1
{
    public interface IRuleHandler<in TRequest, out TResponse>
        where TRequest : IRequest<TResponse>
    {
        TResponse Handle(TRequest message);
    }
}