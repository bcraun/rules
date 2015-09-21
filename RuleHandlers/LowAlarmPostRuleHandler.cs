using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowAlarmPostRuleHandler : 
        IPostRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public async Task HandleAsync(
            LowAlarmRuleExecutor lowAlarmRuleExecutor, 
            IRuleContext context, 
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}