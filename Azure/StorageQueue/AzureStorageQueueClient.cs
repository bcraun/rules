using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace ConsoleApplication1.Azure.StorageQueue
{
    public class AzureStorageQueueClient : 
        IServiceBusClient<
            IServiceBusQueueNameFactory,
            IServiceBusConnectionStringFactory,
            INetlinkServiceBusMessage>

    {
        private string _connectionString;
        private string _queueName;
        private CloudQueueClient _queueClient;
        private CloudQueue _queue;

        private readonly IServiceBusQueueNameFactory _queueNameFactory;
        private readonly IServiceBusConnectionStringFactory _connectionStringFactory;

        public AzureStorageQueueClient(
            IServiceBusQueueNameFactory queueNameFactory,
            IServiceBusConnectionStringFactory connectionStringFactory) 
        {
            _queueNameFactory = queueNameFactory;
            _connectionStringFactory = connectionStringFactory;
        }

        public async Task<IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage>> CreateClientAsync()
        {
            _connectionString = _connectionStringFactory.Make();
            _queueName = _queueNameFactory.Make();

            var storageAccount = CloudStorageAccount.Parse(_connectionString);
            _queueClient = storageAccount.CreateCloudQueueClient();

            ServicePointManager.FindServicePoint(storageAccount.QueueEndpoint).UseNagleAlgorithm = false;

            _queue = _queueClient.GetQueueReference(_queueName);

            _queue.CreateIfNotExists();

            return await Task.FromResult(this);
        }

        public async Task CreateQueueAsync(string queueName)
        {
            _queueName = _queueNameFactory.Make();

            _queue = _queueClient.GetQueueReference(_queueName);

            await _queue.CreateIfNotExistsAsync();
        }

        public async Task SendAsync(INetlinkServiceBusMessage message)
        {
            try
            {
                await Task.Factory
                    .StartNew(() => JsonConvert.SerializeObject(message))
                    .ContinueWith(t =>
                    {
                        if (t.Exception != null)
                        {
                            // TODO: Log the non-transient exception
                        }
                        else
                        {
                            var notificationMessage = new CloudQueueMessage(t.Result);
                            _queue.AddMessageAsync(notificationMessage);
                        }
                    });
            }
            catch (Exception)
            {
                // TODO: Log message
            }
        }

        public async Task<INetlinkServiceBusMessage> ReceiveAsync(TimeSpan? timeout)
        {
            try
            {
                var retrievedJson = await _queue.GetMessageAsync();

                var receivedMessage = JsonConvert.DeserializeObject<NetlinkPointNotificationMessage>(retrievedJson.AsString);

                // Async delete the message
                await _queue.DeleteMessageAsync(retrievedJson);

                return receivedMessage;
            }
            catch (Exception)
            {
                // TODO: Log message
            }

            return null;
        }

        public Task CloseAsync()
        {
            throw new NotImplementedException();
        }
    }
}
