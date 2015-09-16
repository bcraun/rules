namespace ConsoleApplication1
{
    public interface IRulePostHandler<in TRequest, in TResponse>
    {
        void Handle(TRequest request, IRuleContext context, TResponse response);
    }
}