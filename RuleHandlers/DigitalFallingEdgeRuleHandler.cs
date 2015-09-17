namespace ConsoleApplication1
{
    public class DigitalFallingEdgeRuleHandler : 
        IRuleHandler<DigitalFallingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            DigitalFallingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).AlarmOnZero ? 
                executor.ExecuteRule(context) : 
                new RuleExecutionResponse { CurrentState = CurrentStateType.Disabled };
        }
    }
}