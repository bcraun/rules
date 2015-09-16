namespace ConsoleApplication1
{
    public class DigitalRisingEdgeRuleHandler : IRuleHandler<DigitalRisingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(DigitalRisingEdgeRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext)context;

            if (ctx.AlarmOnOne)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}