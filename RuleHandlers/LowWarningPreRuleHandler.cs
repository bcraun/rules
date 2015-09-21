using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowWarningPreRuleHandler : 
        IPreRuleHandler<LowWarningRuleExecutor>
    {
        public async Task HandleASync(
            LowWarningRuleExecutor executor, 
            IRuleContext context)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}