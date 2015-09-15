namespace ConsoleApplication1
{
    public interface IPointRulePreHandler<in TRequest>
    {
        void Handle(TRequest request);
    }
}