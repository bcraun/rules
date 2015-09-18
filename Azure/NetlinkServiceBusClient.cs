using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ConsoleApplication1
{
    public class NetlinkServiceBusClient :
        IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage>
    {
        private string _connectionString;
        private string _queueName;
        private QueueClient _queueClient;
        private readonly NotificationsServiceBusQueueNameFactory _serviceBusQueueNameFactory;
        private readonly NotificationsQueueConnectionStringFactory _queueConnectionStringFactory;
        private const int MaxRetries = 5;
        private int _retriesRemaining = 5;
        private TimeSpan ReceiveTimeoutMilliseconds = TimeSpan.FromMilliseconds(500);

        public NetlinkServiceBusClient(
            NotificationsServiceBusQueueNameFactory serviceBusQueueNameFactory, 
            NotificationsQueueConnectionStringFactory _queueConnectionStringFactory) 
        {
            _serviceBusQueueNameFactory = serviceBusQueueNameFactory;
            this._queueConnectionStringFactory = _queueConnectionStringFactory;
        }

        public async Task<IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage>> CreateClientAsync()
        {
            
            _connectionString = _queueConnectionStringFactory.Make();
            _queueName = _serviceBusQueueNameFactory.Create();
            
            _queueClient = QueueClient.CreateFromConnectionString(_connectionString, _queueName);

            return await Task.FromResult(this);
        }

        public async Task CreateQueueAsync(string queueName)
        {
            var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            if (!namespaceManager.QueueExists(queueName))
            {
                await namespaceManager.CreateQueueAsync(queueName);
            }
        }

        // TODO: Figure out why async crashes
        public async Task SendAsync(INetlinkServiceBusMessage message)
        {
//            await _queueClient.SendAsync(new BrokeredMessage(message)).ContinueWith(t =>
//            {
//                if (t.Exception != null)
//                {
//                    // Throw any exceptions that cannot be handled here
//                    throw t.Exception.Flatten();
//                }
//            });
            Send(message);
        }

        public void Send(INetlinkServiceBusMessage message)
        {
            while (true)
            {
                try
                {
                    var brokeredMessage = new BrokeredMessage(message);
                    _queueClient.Send(brokeredMessage);
                }
                catch (MessagingException e)
                {
                    if (!e.IsTransient)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                    HandleTransientErrors(e);
                }
                break;
            }
        }

        // TODO: Figure out why async crashes
        public async Task<INetlinkServiceBusMessage> ReceiveAsync(TimeSpan? timeout)
        {
//            while (true)
//            {
//                try
//                {
//                    var message = await _queueClient.ReceiveAsync(TimeSpan.FromSeconds(5));
//                    if (message != null)
//                    {
//                        await message.CompleteAsync();
//                        return message.GetBody<NetlinkPointNotificationMessage>();
//                    }
//                    break;
//                }
//                catch (MessagingException e)
//                {
//                    HandleTransientErrors(e);
//                }
//            }
//            return null;

            if (timeout.HasValue)
            {
                return Receive(timeout.Value);
            }

            return Receive(ReceiveTimeoutMilliseconds);
        }

        private INetlinkServiceBusMessage Receive(TimeSpan timeout)
        {
            while (true)
            {
                try
                {
                    var message = _queueClient.Receive(timeout);
                    if (message != null)
                    {
                        message.Complete();
                        return message.GetBody<NetlinkPointNotificationMessage>();
                    }
                    break;
                }
                catch (MessagingException e)
                {
                    HandleTransientErrors(e);
                }
            }
            return null;
        }

        private void HandleTransientErrors(MessagingException messagingException)
        {
            if ((!messagingException.IsTransient) && (_retriesRemaining > 0))
            {
                return;
            }
            Thread.Sleep(2000);
            _retriesRemaining = MaxRetries - 1;
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