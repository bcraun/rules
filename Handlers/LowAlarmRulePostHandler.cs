namespace ConsoleApplication1
{
    public class LowAlarmRulePostHandler : IRulePostHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(LowAlarmRuleExecutor lowAlarmRuleExecutor, IRuleContext context, RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}