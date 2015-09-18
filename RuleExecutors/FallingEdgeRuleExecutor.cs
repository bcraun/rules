using System;
using System.Linq;

namespace ConsoleApplication1
{
    public class FallingEdgeRuleExecutor : IRuleExecutor
    {
        private readonly IRuleEngineFactory<double> _engineFactory;
        private IRuleFactory<double>[] RuleFactory { get; }

        public FallingEdgeRuleExecutor(
            IRuleFactory<double>[] ruleFactory, 
            IRuleEngineFactory<double> engineFactory)
        {
            _engineFactory = engineFactory;
            RuleFactory = ruleFactory;
        }

        public RuleExecutionResponse ExecuteRule(IRuleContext<double> context)
        {
            var pointContext = (PointRuleContext)context;
            var result = new RuleExecutionResponse { CurrentState = CurrentStateType.Normal };

            double actual = pointContext.CurrentValue;
            double previous = pointContext.LastValue;

            if (Math.Abs(context.CurrentValue - context.LastValue) > 0)
            {
                // Values are different. Run rule
                var rule = RuleFactory.First(r => r.GetType() == typeof (DoubleLessThanRuleFactory)).Make(previous);

                var ruleEngine = _engineFactory.Make(actual);
                ruleEngine.Add(rule);

                // TODO: Interpret the result and update the RuleExecutionResponse enum
                if (ruleEngine.MatchAny())
                {
                    if (context.BooleanAlarmState == Convert.ToInt32(actual))
                    {
                        result.CurrentState = CurrentStateType.DigitalIntoAlarmTransition;
                    }
                    else
                    {
                        result.CurrentState = CurrentStateType.DigitalOutOfAlarmTransition;
                    }

                    // TODO: Update the actor with alarm state
                }
            }

            return result;
        }
    }
}