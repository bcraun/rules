namespace ConsoleApplication1
{
    public class LowWarningPreRuleHandler : 
        IPreRuleHandler<LowWarningRuleExecutor, ScaledRuleExecutionResponse>
    {
        public ScaledRuleExecutionResponse Handle(
            LowWarningRuleExecutor executor, 
            IRuleContext<double> context)
        {
            // TODO: Implement point value scaling which updates the context with scaled value
            context.ScaledValue = 42.411;
            return new ScaledRuleExecutionResponse { Context = context };
        }
    }
}