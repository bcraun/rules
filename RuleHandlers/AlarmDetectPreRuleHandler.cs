using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AlarmDetectPreRuleHandler : 
        IPreRuleHandler<AlarmDetectRuleExecutor>
    {
        public async Task HandleASync(
            AlarmDetectRuleExecutor executor, 
            IRuleContext context)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}