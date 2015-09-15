using System.Linq;

namespace ConsoleApplication1
{
    public class PointWarningRuleRequest : IRequest<RuleResponse>
    {
        public IRuleFactory<double>[] RuleFactory { get; set; }

        public PointWarningRuleRequest(IRuleFactory<double>[] ruleFactory)
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

            double actual = 323.23;
            double threshold = 50.034;

            var rule = RuleFactory.First().MakeRule(threshold);

            var integerRuleEngine = new RuleEngine<double> { ActualValue = actual };
            integerRuleEngine.Add(rule);

            return new RuleResponse { Result = integerRuleEngine.MatchAny() };
        }
    }
}