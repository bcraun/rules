namespace ConsoleApplication1
{
    public class DoubleGreaterThanEqualToRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> Make(double threshold) => new DoubleGreaterThanEqualToRule(threshold);
    }
}