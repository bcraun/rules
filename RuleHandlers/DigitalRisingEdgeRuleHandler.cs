namespace ConsoleApplication1
{
    public class DigitalRisingEdgeRuleHandler : 
        IRuleHandler<DigitalRisingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            DigitalRisingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).AlarmOnOne ? 
                executor.ExecuteRule(context) :
                new RuleExecutionResponse { CurrentState = CurrentStateType.Disabled };
        }
    }
}