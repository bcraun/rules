namespace ConsoleApplication1
{
    public class LowAlarmRuleHandler : IRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(LowAlarmRuleExecutor message, IRuleContext<double> context)
        {
            var ctx = (DoubleRuleContext)context;

            if (ctx.LowAlarmEnabled)
            {
                return message.ExecuteRule(context);
            }

            return default(RuleExecutionResponse);
        }
    }
}