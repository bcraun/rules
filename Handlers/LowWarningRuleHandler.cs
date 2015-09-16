namespace ConsoleApplication1
{
    public class LowWarningRuleHandler : IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(LowWarningRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}