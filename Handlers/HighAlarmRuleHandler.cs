namespace ConsoleApplication1
{
    public class HighAlarmRuleHandler : IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(HighAlarmRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}