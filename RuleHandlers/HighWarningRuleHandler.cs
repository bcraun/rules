namespace ConsoleApplication1
{
    public class HighWarningRuleHandler : 
        IRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            HighWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).HighWarningEnabled ? 
                executor.ExecuteRule(context) :
                new RuleExecutionResponse { CurrentState = CurrentStateType.PointDisabled };
        }
    }
}