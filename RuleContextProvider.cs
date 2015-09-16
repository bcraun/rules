namespace ConsoleApplication1
{
    class RuleContextProvider : IRuleContextProvider
    {
        public DoubleRuleContext GetRuleContext(IRuleContext context)
        {
            // TODO: Call the point actor
            return new DoubleRuleContext();
        }
    }
}