using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowWarningRuleHandler : 
        IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse HandleAsync(
            LowWarningRuleExecutor executor, 
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