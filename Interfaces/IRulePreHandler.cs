namespace ConsoleApplication1
{
    public interface IRulePreHandler<in TRequest>
    {
        void Handle(TRequest request, IRuleContext context);
    }
}