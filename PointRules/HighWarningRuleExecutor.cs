using System.Linq;

namespace ConsoleApplication1
{
    public class HighWarningRuleExecutor : IRuleExecutor
    {
        public IRuleFactory<double>[] RuleFactory { get; set; }

        public HighWarningRuleExecutor(IRuleFactory<double>[] ruleFactory)
        {
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext context)
        {
            var pointContext = (DoubleRuleContext) context;

            double actual = pointContext.CurrentValue;
            double threshold = pointContext.HighWarningValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleGreaterThanRuleFactory)).MakeRule(threshold);

            var ruleEngine = new RuleEngine<double> { ActualValue = actual };
            ruleEngine.Add(rule);

            return new RuleExecutionResponse { Result = ruleEngine.MatchAny() };
        }
    }
}