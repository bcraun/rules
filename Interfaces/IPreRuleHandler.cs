namespace ConsoleApplication1
{
    public interface IPreRuleHandler<in TRuleExecutor>
    {
        void Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context);
    }
}