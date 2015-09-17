
namespace ConsoleApplication1
{
    public class HighAlarmPreRuleHandler : 
        IPreRuleHandler<HighAlarmRuleExecutor, ScaledRuleExecutionResponse>
    {
        public ScaledRuleExecutionResponse Handle(
            HighAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
            context.ScaledValue = 23.634;
            return new ScaledRuleExecutionResponse {Context = context};
        }
    }
}