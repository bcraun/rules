namespace ConsoleApplication1
{
    public class HighAlarmRuleHandler :
        IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            HighAlarmRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).HighAlarmEnabled ? 
                executor.ExecuteRule(context) : 
                default(RuleExecutionResponse);
        }
    }
}