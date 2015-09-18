namespace ConsoleApplication1
{
    public class RisingEdgeRuleHandler : 
        IRuleHandler<RisingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            RisingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).NotificationLevel > 0 ?
                executor.ExecuteRule(context) :
                new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}