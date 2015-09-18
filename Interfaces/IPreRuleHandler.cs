namespace ConsoleApplication1
{
    public interface IPreRuleHandler<TRuleExecutor>
    {
        void Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context);
    }
}