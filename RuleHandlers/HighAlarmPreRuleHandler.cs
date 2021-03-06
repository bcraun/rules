﻿
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighAlarmPreRuleHandler : 
        IPreRuleHandler<HighAlarmRuleExecutor>
    {
        public async Task HandleASync(
            HighAlarmRuleExecutor executor, 
            IRuleContext context)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}