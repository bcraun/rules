namespace ConsoleApplication1
{
    public class LowWarningPreRuleHandler : 
        IPreRuleHandler<LowWarningRuleExecutor>
    {
        public void Handle(
            LowWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}