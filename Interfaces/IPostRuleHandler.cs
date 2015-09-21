using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IPostRuleHandler<TRuleExecutor, TResponse>
    {
        Task HandleAsync(
            TRuleExecutor executor, 
            IRuleContext context, 
            TResponse response,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient);
    }
}