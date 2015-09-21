using System;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ConsoleApplication1
{
    public class AzureServiceBusClient :
        IServiceBusClient<IServiceBusQueueNameFactory, 
            IServiceBusConnectionStringFactory, 
            INetlinkServiceBusMessage>
    {
        private string _connectionString;
        private string _queueName;
        private QueueClient _queueClient;
        private readonly QueueNameFactory _serviceBusQueueNameFactory;
        private readonly ConnectionStringFactory _queueConnectionStringFactory;
        private readonly TimeSpan _receiveTimeoutMilliseconds = TimeSpan.FromMilliseconds(500);

        public AzureServiceBusClient(
            QueueNameFactory serviceBusQueueNameFactory, 
            ConnectionStringFactory queueConnectionStringFactory) 
        {
            _serviceBusQueueNameFactory = serviceBusQueueNameFactory;
            _queueConnectionStringFactory = queueConnectionStringFactory;
        }

        public async Task<IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage>> CreateClientAsync()
        {
            _connectionString = _queueConnectionStringFactory.Make();
            _queueName = _serviceBusQueueNameFactory.Make();
            
            _queueClient = QueueClient.CreateFromConnectionString(_connectionString, _queueName);

            return await Task.FromResult(this);
        }

        public async Task CreateQueueAsync(string queueName)
        {
            var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!await namespaceManager.QueueExistsAsync(queueName))
            {
                await namespaceManager.CreateQueueAsync(queueName);
            }
        }

        public async Task SendAsync(INetlinkServiceBusMessage message)
        {
            await _queueClient.SendAsync(new BrokeredMessage(message)).ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    // TODO: Log messages
                    //throw t.Exception.Flatten();
                }
            });
        }

        public void Send(INetlinkServiceBusMessage message)
        {
            try
            {
                var brokeredMessage = new BrokeredMessage(message);
                _queueClient.Send(brokeredMessage);
            }
            catch (MessagingException)
            {
                // TODO: Log message
            }
        }

        public async Task<INetlinkServiceBusMessage> ReceiveAsync(TimeSpan? timeout)
        {
            var tout = timeout ?? _receiveTimeoutMilliseconds;

            try
            {
                // TODO: Figure out why async crashes
                var message = await _queueClient.ReceiveAsync(TimeSpan.FromSeconds(tout.Milliseconds));

                if (message != null)
                {
                    await message.CompleteAsync();
                    return message.GetBody<NetlinkPointNotificationMessage>();
                }
            }
            catch (MessagingException)
            {
                // TODO: Log message
            }
            return null;
        }

        public async Task CloseAsync()
        {
            if (!_queueClient.IsClosed)
            {
                await _queueClient.CloseAsync();
            }
        }
    }
}