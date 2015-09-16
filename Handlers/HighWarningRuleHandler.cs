namespace ConsoleApplication1
{
    public class HighWarningRuleHandler : IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(HighWarningRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext)context;

            if (ctx.HighWarningEnabled)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}