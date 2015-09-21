using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighWarningRuleExecutor : IRuleExecutor    //<RuleExecutionResponse>
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public HighWarningRuleExecutor(
            IRuleFactory<double>[] ruleFactory, 
            IRuleEngineFactory<double> engineFactory)
        {
            _engineFactory = engineFactory;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRuleAsync(IRuleContext context)
        {
            var pointContext = (PointRuleContext) context;

            double actual = (double) pointContext.CurrentValue;
            double threshold = pointContext.HighWarningValue;

            var rule = RuleFactory.First(r => r.GetType() == typeof(DoubleGreaterThanRuleFactory)).Make(threshold);

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            var result = new RuleExecutionResponse();
            // TODO: Interpret the result and update the RuleExecutionResponse enum
            if (ruleEngine.MatchAny())
            {
                result.CurrentState = CurrentStateType.AnalogHighWarning;
            }

            return result;
        }
    }
}