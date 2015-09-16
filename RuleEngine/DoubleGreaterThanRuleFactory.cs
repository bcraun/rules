namespace ConsoleApplication1
{
    public class DoubleGreaterThanRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> Make(double threshold) => new DoubleGreaterThanRule(threshold);
    }
}