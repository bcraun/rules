namespace ConsoleApplication1
{
    public class HighWarningPreRuleHandler : 
        IPreRuleHandler<HighWarningRuleExecutor, ScaledRuleExecutionResponse>
    {
        public ScaledRuleExecutionResponse Handle(
            HighWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
            context.ScaledValue = 48.788;
            return new ScaledRuleExecutionResponse { Context = context };
        }
    }
}