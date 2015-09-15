namespace ConsoleApplication1
{
    public interface IPointRulePostHandler<in TRequest, in TResponse>
    {
        void Handle(TRequest request, TResponse response);
    }
}