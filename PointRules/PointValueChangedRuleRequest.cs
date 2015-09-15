using System.Linq;

namespace ConsoleApplication1
{
    public class PointValueChangedRuleRequest : IRequest<RuleResponse>
    {
        public IRuleFactory<double>[] RuleFactory { get; set; }

        public PointValueChangedRuleRequest(IRuleFactory<double>[] ruleFactory)
        {
            RuleFactory = ruleFactory;
        }

        public RuleResponse ExecuteRule()
        {
            // TODO: Ideally, should inject a values provider that would retrieve all required  
            // TODO: state values to decouple the Service Fabric calls away from rules engine.
            // TODO: Point configuration, last value, current value

            // TODO: Call the point actor to retrieve the current value from state?
            // TODO: Call the point actor to retrieve the previous value from state?

            double actual = 23.3213;
            double threshold = 23.3214;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleEqualToRuleFactory)).MakeRule(threshold);

            var integerRuleEngine = new RuleEngine<double> { ActualValue = actual };
            integerRuleEngine.Add(rule);

            return new RuleResponse { Result = integerRuleEngine.MatchAny() };
        }
    }
}