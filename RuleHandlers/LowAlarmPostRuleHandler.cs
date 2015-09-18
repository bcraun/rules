using System;

namespace ConsoleApplication1
{
    public class LowAlarmPostRuleHandler : 
        IPostRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(
            LowAlarmRuleExecutor lowAlarmRuleExecutor, 
            IRuleContext<double> context, 
            RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}