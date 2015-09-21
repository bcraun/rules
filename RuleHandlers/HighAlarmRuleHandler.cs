using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighAlarmRuleHandler :
        IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse HandleAsync(
            HighAlarmRuleExecutor executor, 
            IRuleContext context)
        {
            if (context.IsEnabled)
            {
                return executor.ExecuteRuleAsync(context);
            }
            return  new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}