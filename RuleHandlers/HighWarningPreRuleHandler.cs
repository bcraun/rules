namespace ConsoleApplication1
{
    public class HighWarningPreRuleHandler : 
        IPreRuleHandler<HighWarningRuleExecutor>
    {
        public void Handle(
            HighWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
        }
    }
}