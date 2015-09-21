namespace ConsoleApplication1
{
    class IntegerRuleEngineFactory : IRuleEngineFactory<int>
    {
        public RuleEngine<int> Make(int value)
        {
            return new RuleEngine<int> { ActualValue = value }; ;
        }
    }
}