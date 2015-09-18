using System.Linq;

namespace ConsoleApplication1
{
    public class RisingEdgeRuleExecutor : IRuleExecutor
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public RisingEdgeRuleExecutor(
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
            double previous = pointContext.LastValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleGreaterThanRuleFactory)).Make(previous);

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            var result = new RuleExecutionResponse();
            // TODO: Interpret the result and update the RuleExecutionResponse enum
            if (ruleEngine.MatchAny())
            {
                //result.CurrentState = CurrentStateType.;
            }

            return result;
        }
    }
}