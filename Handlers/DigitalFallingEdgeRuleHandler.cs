namespace ConsoleApplication1
{
    public class DigitalFallingEdgeRuleHandler : IRuleHandler<DigitalFallingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(DigitalFallingEdgeRuleExecutor message, IRuleContext context)
        {
            return message.ExecuteRule(context);
        }
    }
}