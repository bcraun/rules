namespace ConsoleApplication1
{
    public interface IRuleEngineFactory<T>
    {
        RuleEngine<T> Make(T value);
    }

    class DoubleRuleEngineFactory : IRuleEngineFactory<double>
    {
        public RuleEngine<double> Make(double value)
        {
            return new RuleEngine<double> { ActualValue = value }; ;
        }
    }
}