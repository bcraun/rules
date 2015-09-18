namespace ConsoleApplication1
{
    public class NotificationsServiceBusQueueNameFactory : IServiceBusQueueNameFactory
    {
        public string Create()
        {
            return "netlinkv2-notifications-sb";
        }
    }
}