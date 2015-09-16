namespace ConsoleApplication1
{
    public class DigitalFallingEdgeRuleHandler : IRuleHandler<DigitalFallingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(DigitalFallingEdgeRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext) context;

            if (ctx.AlarmOnZero)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}