namespace ConsoleApplication1
{
    public class LowWarningRuleHandler : IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(LowWarningRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext)context;

            if (ctx.LowWarningEnabled)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}