namespace ConsoleApplication1
{
    public class LowAlarmRuleHandler : IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(LowAlarmRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}