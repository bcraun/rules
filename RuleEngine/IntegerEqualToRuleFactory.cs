namespace ConsoleApplication1
{
    public class IntegerEqualToRuleFactory : IRuleFactory<int>
    {
        public BaseRule<int> Make(int threshold) => new IntegerEqualToRule(threshold);
    }
}