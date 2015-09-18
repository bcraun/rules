namespace ConsoleApplication1
{
    public interface IPostRuleHandler<TRuleExecutor, TResponse>
    {
        void Handle(
            TRuleExecutor executor, 
            IRuleContext<double> context, 
            TResponse response,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient);
    }
}