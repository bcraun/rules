using System.Linq;

namespace ConsoleApplication1
{
    public class HighAlarmRuleExecutor : IRuleExecutor
    {
        private readonly IRuleContextProvider _ruleContextProvider;
        public IRuleFactory<double>[] RuleFactory { get; set; }

        public HighAlarmRuleExecutor(IRuleFactory<double>[] ruleFactory, IRuleContextProvider ruleContextProvider)
        {
            _ruleContextProvider = ruleContextProvider;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext context)
        {
            var pointContext = (DoubleRuleContext)context;

            double actual = pointContext.CurrentValue;
            double threshold = pointContext.HighAlarmValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleGreaterThanRuleFactory)).MakeRule(threshold);

            var integerRuleEngine = new RuleEngine<double> { ActualValue = actual };
            integerRuleEngine.Add(rule);

            return new RuleExecutionResponse { Result = integerRuleEngine.MatchAny() };
        }
    }
}