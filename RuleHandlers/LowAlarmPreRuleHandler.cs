namespace ConsoleApplication1
{
    public class LowAlarmPreRuleHandler : 
        IPreRuleHandler<LowAlarmRuleExecutor>
    {
        public void Handle(
            LowAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}