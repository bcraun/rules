namespace ConsoleApplication1
{
    public interface IPostRuleHandler<in TRequest, in TResponse>
    {
        void Handle(TRequest request, TResponse response);
    }
}