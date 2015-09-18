namespace ConsoleApplication1
{
    public class HighAlarmRuleHandler :
        IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            HighAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // Is the rule enabled?

            // If enabled, is the current value different from last value

            // If different, run the rule

            // Return the RuleExecutionResponse which contains the new state

            return ((PointRuleContext)context).HighAlarmEnabled ? 
                executor.ExecuteRule(context) :
                new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}