namespace ConsoleApplication1
{
    public class BooleanEqualToRuleFactory : IRuleFactory<bool>
    {
        public BaseRule<bool> Make(bool threshold) => new BooleanEqualToRule(threshold);
    }
}