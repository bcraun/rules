
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighAlarmPostRuleHandler : 
        IPostRuleHandler<HighAlarmRuleExecutor, RuleExecutionResponse>
    {
        public async Task HandleAsync(
            HighAlarmRuleExecutor highAlarmRuleExecutor, 
            IRuleContext context, 
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}