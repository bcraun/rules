namespace ConsoleApplication1
{
    public interface IRuleHandler<in TRequest, out TResponse>
        where TRequest : IRuleExecutor
    {
        TResponse Handle(TRequest message, IRuleContext<double> context);
    }
}