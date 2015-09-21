using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LowWarningPostRuleHandler : 
        IPostRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public async Task HandleAsync(
            LowWarningRuleExecutor lowWarningRuleExecutor, 
            IRuleContext context, 
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}