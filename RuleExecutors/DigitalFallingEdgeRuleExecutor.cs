using System.Linq;

namespace ConsoleApplication1
{
    public class DigitalFallingEdgeRuleExecutor : IRuleExecutor
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public DigitalFallingEdgeRuleExecutor(
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
            double threshold = pointContext.PreviousValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleLessThanRuleFactory)).Make(threshold);

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            return new RuleExecutionResponse { Result = ruleEngine.MatchAny() };
        }
    }
}