namespace ConsoleApplication1
{
    public class HighWarningRuleHandler : IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(HighWarningRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}