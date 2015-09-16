namespace ConsoleApplication1
{
    class DoubleRuleEngineFactory : IRuleEngineFactory<double>
    {
        public RuleEngine<double> Make(double value)
        {
            return new RuleEngine<double> { ActualValue = value }; ;
        }
    }
}