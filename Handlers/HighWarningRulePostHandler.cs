namespace ConsoleApplication1
{
    public class HighWarningRulePostHandler : IRulePostHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(HighWarningRuleExecutor highWarningRuleExecutor, IRuleContext context, RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}