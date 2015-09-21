using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class HighWarningPostRuleHandler : 
        IPostRuleHandler<HighWarningRuleExecutor, RuleExecutionResponse>
    {
        public async Task HandleAsync(
            HighWarningRuleExecutor highWarningRuleExecutor, 
            IRuleContext context, 
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Implement if needed
            await Task.FromResult(true);
        }
    }
}