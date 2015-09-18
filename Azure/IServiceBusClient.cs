using System;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IServiceBusClient<TQueueNameFactory, TConnectionStringFactory, TMessage>  where TMessage : INetlinkServiceBusMessage
    {
        Task<IServiceBusClient<TQueueNameFactory, TConnectionStringFactory, TMessage>> CreateClientAsync();
        Task CreateQueueAsync(string queueName);
        Task SendAsync(TMessage message);
        Task<TMessage> ReceiveAsync(TimeSpan? timeout);
        Task CloseAsync();
    }
}