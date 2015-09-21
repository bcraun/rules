using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AlarmDetectRuleExecutor : IRuleExecutor    //<RuleExecutionResponse>
    {
        private readonly IRuleEngineFactory<int> _engineFactory;
        private IRuleFactory<int>[] RuleFactory { get; }

        public AlarmDetectRuleExecutor(
            IRuleFactory<int>[] ruleFactory, 
            IRuleEngineFactory<int> engineFactory)
        {
            _engineFactory = engineFactory;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRuleAsync(IRuleContext context)
        {
            var pointContext = (PointRuleContext)context;
            var result = new RuleExecutionResponse { CurrentState = CurrentStateType.Normal };

            int actual = Convert.ToInt32(context.CurrentValue);
            int previous = Convert.ToInt32(pointContext.LastValue);

            var rule = RuleFactory.First(r => r.GetType() == typeof (IntegerEqualToRuleFactory)).Make(Convert.ToInt32(context.BooleanAlarmState));

            var ruleEngine = _engineFactory.Make(actual);
            ruleEngine.Add(rule);

            if (!ruleEngine.MatchAny())
            {
                // Values were different...now determine whether it was into alarm or out of alarm
                result.CurrentState = previous > actual ? CurrentStateType.DigitalOutOfAlarmTransition : CurrentStateType.DigitalIntoAlarmTransition;

                // TODO: Update the actor with alarm state
            }

            return result;
        }
    }
}