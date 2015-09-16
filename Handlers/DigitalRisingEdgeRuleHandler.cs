namespace ConsoleApplication1
{
    public class DigitalRisingEdgeRuleHandler : IRuleHandler<DigitalRisingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(DigitalRisingEdgeRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}