namespace ConsoleApplication1
{
    public class HighAlarmRuleHandler : IRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(HighAlarmRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext)context;

            if (ctx.HighAlarmEnabled)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}