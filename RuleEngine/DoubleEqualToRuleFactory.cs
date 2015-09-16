namespace ConsoleApplication1
{
    public class DoubleEqualToRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> Make(double threshold) => new DoubleEqualToRule(threshold);
    }
}