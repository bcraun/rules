namespace ConsoleApplication1
{
    public class FallingEdgePreRuleHandler : 
        IPreRuleHandler<FallingEdgeRuleExecutor>
    {
        public void Handle(
            FallingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}