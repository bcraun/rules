using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighWarningPreRuleHandler : 
        IPreRuleHandler<HighWarningRuleExecutor>
    {
        public async Task HandleASync(
            HighWarningRuleExecutor executor, 
            IRuleContext context)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}