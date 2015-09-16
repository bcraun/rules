using System.Linq;

namespace ConsoleApplication1
{
    public class LowAlarmRuleExecutor : IRuleExecutor
    {
        private readonly IRuleContextProvider _ruleContextProvider;
        public IRuleFactory<double>[] RuleFactory { get; set; }

        public LowAlarmRuleExecutor(IRuleFactory<double>[] ruleFactory, IRuleContextProvider ruleContextProvider)
        {
            _ruleContextProvider = ruleContextProvider;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext<double> context)
        {
            var pointContext = (DoubleRuleContext)context;

            double actual = pointContext.CurrentValue;
            double threshold = pointContext.LowAlarmValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleLessThanRuleFactory)).MakeRule(threshold);

            var ruleEngine = new RuleEngine<double> { ActualValue = actual };
            ruleEngine.Add(rule);

            return new RuleExecutionResponse { Result = ruleEngine.MatchAny() };
        }
    }
}