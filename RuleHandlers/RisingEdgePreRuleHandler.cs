namespace ConsoleApplication1
{
    public class RisingEdgePreRuleHandler : 
        IPreRuleHandler<RisingEdgeRuleExecutor>
    {
        public void Handle(
            RisingEdgeRuleExecutor executor, 
            IRuleContext<double> context)
        {
        }
    }
}