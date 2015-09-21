using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowAlarmPreRuleHandler : 
        IPreRuleHandler<LowAlarmRuleExecutor>
    {
        public async Task HandleASync(
            LowAlarmRuleExecutor executor, 
            IRuleContext context)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}