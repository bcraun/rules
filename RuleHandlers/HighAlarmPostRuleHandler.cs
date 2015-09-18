using System;

namespace ConsoleApplication1
{
    public class HighAlarmPostRuleHandler : 
        IPostRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(
            HighAlarmRuleExecutor highAlarmRuleExecutor, 
            IRuleContext<double> context, 
            RuleExecutionResponse ruleExecutionResponse)
        {
            // TODO: Plug in the notification or alarm if rule response was true
        }
    }
}