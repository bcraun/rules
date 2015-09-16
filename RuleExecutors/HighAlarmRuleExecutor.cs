using System.Linq;

namespace ConsoleApplication1
{
    public class HighAlarmRuleExecutor : IRuleExecutor
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public HighAlarmRuleExecutor(
            IRuleFactory<double>[] ruleFactory, 
            IRuleEngineFactory<double> engineFactory)
        {
            _engineFactory = engineFactory;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext<double> context)
        {
            var pointContext = (PointRuleContext)context;

            double actual = pointContext.CurrentValue;
            double threshold = pointContext.HighAlarmValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleGreaterThanRuleFactory)).Make(threshold);

            var integerRuleEngine = _engineFactory.Make(actual);
            integerRuleEngine.Add(rule);

            return new RuleExecutionResponse { Result = integerRuleEngine.MatchAny() };
        }
    }
}