namespace ConsoleApplication1
{
    public class HighWarningPreRuleHandler : 
        IPreRuleHandler<HighWarningRuleExecutor>
    {
        public void Handle(
            HighWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}