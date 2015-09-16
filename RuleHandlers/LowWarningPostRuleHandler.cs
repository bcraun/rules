namespace ConsoleApplication1
{
    public class LowWarningPostRuleHandler : 
        IPostRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(
            LowWarningRuleExecutor lowWarningRuleExecutor, 
            IRuleContext<double> context, 
            RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}