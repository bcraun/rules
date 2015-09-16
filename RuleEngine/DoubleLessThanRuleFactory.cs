namespace ConsoleApplication1
{
    public class DoubleLessThanRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> MakeRule(double threshold) => new DoubleLessThanRule(threshold);
    }
}