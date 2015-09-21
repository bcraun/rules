using System;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AlarmDetectRuleHandler : 
        IRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse HandleAsync(
            AlarmDetectRuleExecutor executor, 
            IRuleContext context)
        {
            if (context.IsEnabled)
            {
                return executor.ExecuteRuleAsync(context);
            }
            return new RuleExecutionResponse {CurrentState = CurrentStateType.PointDisabled};
        }
    }
}