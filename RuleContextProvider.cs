namespace ConsoleApplication1
{
    class RuleContextProvider : IRuleContextProvider
    {
        public DoubleRuleContext GetRuleContext(IRuleContext<double> context)
        {
            // TODO: Call the point actor
            return new DoubleRuleContext();
        }
    }
}