namespace ConsoleApplication1
{
    public class IntegerLessThanRuleFactory : IRuleFactory<int>
    {
        public BaseRule<int> MakeRule(int threshold) => new IntegerGreaterThanRule(threshold);
    }
}