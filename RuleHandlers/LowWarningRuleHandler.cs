namespace ConsoleApplication1
{
    public class LowWarningRuleHandler : 
        IRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public RuleExecutionResponse Handle(
            LowWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            return ((PointRuleContext)context).LowWarningEnabled ? 
                executor.ExecuteRule(context) :
                new RuleExecutionResponse {CurrentState = CurrentStateType.Disabled};
        }
    }
}