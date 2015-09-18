namespace ConsoleApplication1
{
    public class FallingEdgeRuleHandler : 
        IRuleHandler<FallingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            FallingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {

            return ((PointRuleContext)context).NotificationLevel > 0 ? 
                executor.ExecuteRule(context) : 
                new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}