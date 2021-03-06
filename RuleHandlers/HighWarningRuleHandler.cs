using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighWarningRuleHandler : 
        IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse HandleAsync(
            HighWarningRuleExecutor executor, 
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