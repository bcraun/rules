namespace ConsoleApplication1
{
    class BooleanRuleEngineFactory : IRuleEngineFactory<bool>
    {
        public RuleEngine<bool> Make(bool value)
        {
            return new RuleEngine<bool> { ActualValue = value }; ;
        }
    }
}