namespace ConsoleApplication1
{
    public class QueueNameFactory : IServiceBusQueueNameFactory
    {
        public string Make()
        {
            return "netlinkv2notifications";
        }
    }
}