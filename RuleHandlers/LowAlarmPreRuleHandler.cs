namespace ConsoleApplication1
{
    public class LowAlarmPreRuleHandler : 
        IPreRuleHandler<LowAlarmRuleExecutor, ScaledRuleExecutionResponse>
    {
        public ScaledRuleExecutionResponse Handle(
            LowAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
            context.ScaledValue = 38.432;
            return new ScaledRuleExecutionResponse { Context = context };
        }
    }
}