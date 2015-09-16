namespace ConsoleApplication1
{
    public class DoubleGreaterThanRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> MakeRule(double threshold) => new DoubleGreaterThanRule(threshold);
    }
}