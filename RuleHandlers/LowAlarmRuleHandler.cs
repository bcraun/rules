namespace ConsoleApplication1
{
    public class LowAlarmRuleHandler : 
        IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            LowAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).LowAlarmEnabled ? 
                executor.ExecuteRule(context) : 
                default(RuleExecutionResponse);
        }
    }
}