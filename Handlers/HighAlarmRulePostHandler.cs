namespace ConsoleApplication1
{
    public class HighAlarmRulePostHandler : IRulePostHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(HighAlarmRuleExecutor highAlarmRuleExecutor, IRuleContext<double> context, RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}