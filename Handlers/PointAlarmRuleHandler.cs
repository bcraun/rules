namespace ConsoleApplication1
{
    public class PointAlarmRuleHandler : IPointRuleHandler<PointAlarmRuleRequest, RuleResponse>
    {
        public RuleResponse Handle(PointAlarmRuleRequest message)
        {
            return message.ExecuteRule();
        }
    }

    public class PointWarningRuleHandler : IPointRuleHandler<PointWarningRuleRequest, RuleResponse>
    {
        public RuleResponse Handle(PointWarningRuleRequest message)
        {
            return message.ExecuteRule();
        }
    }
    public class PointValueChangedRuleHandler : IPointRuleHandler<PointValueChangedRuleRequest, RuleResponse>
    {
        public RuleResponse Handle(PointValueChangedRuleRequest message)
        {
            return message.ExecuteRule();
        }
    }
}