namespace ConsoleApplication1
{
    public interface IPreRuleHandler<in TRequest>
    {
        void Handle(TRequest request);
    }
}