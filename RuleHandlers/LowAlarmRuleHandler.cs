using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowAlarmRuleHandler : 
        IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse HandleAsync(
            LowAlarmRuleExecutor executor, 
            IRuleContext context)
        {
            if (context.IsEnabled)
            {
                return executor.ExecuteRuleAsync(context);
            }
            return new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}