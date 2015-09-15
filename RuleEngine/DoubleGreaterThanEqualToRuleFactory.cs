namespace ConsoleApplication1
{
    public class DoubleGreaterThanEqualToRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> MakeRule(double threshold) => new DoubleGreaterThanEqualToRule(threshold);
    }
}