using System.Configuration;

namespace ConsoleApplication1
{
    public class ConnectionStringFactory : IServiceBusConnectionStringFactory
    {
        public string Make()
        {
            return ConfigurationManager.AppSettings["NetlinkV2NotificationsQueueConnectionString"];
        }
    }
}