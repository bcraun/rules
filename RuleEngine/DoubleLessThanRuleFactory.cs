namespace ConsoleApplication1
{
    public class DoubleLessThanRuleFactory : IRuleFactory<double>
    {
        public BaseRule<double> Make(double threshold) => new DoubleLessThanRule(threshold);
    }
}