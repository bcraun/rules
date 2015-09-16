
namespace ConsoleApplication1
{
    public class HighAlarmPreRuleHandler : 
        IPreRuleHandler<HighAlarmRuleExecutor>
    {
        public void Handle(
            HighAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}