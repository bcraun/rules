namespace ConsoleApplication1
{
    public class DoubleEqualToRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> MakeRule(double threshold) => new DoubleEqualToRule(threshold);
    }
}