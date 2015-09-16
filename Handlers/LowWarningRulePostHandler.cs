namespace ConsoleApplication1
{
    public class LowWarningRulePostHandler : IRulePostHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(LowWarningRuleExecutor lowWarningRuleExecutor, IRuleContext context, RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}