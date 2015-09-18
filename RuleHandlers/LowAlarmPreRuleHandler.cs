namespace ConsoleApplication1
{
    public class LowAlarmPreRuleHandler : 
        IPreRuleHandler<LowAlarmRuleExecutor>
    {
        public void Handle(
            LowAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
        }
    }
}