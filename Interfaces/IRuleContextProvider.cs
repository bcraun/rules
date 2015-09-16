namespace ConsoleApplication1
{
    public interface IRuleContextProvider
    {
        DoubleRuleContext GetRuleContext(IRuleContext context);
    }
}