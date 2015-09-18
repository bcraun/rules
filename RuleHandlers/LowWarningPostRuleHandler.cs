using System;

namespace ConsoleApplication1
{
    public class LowWarningPostRuleHandler : 
        IPostRuleHandler<LowWarningRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(
            LowWarningRuleExecutor lowWarningRuleExecutor, 
            IRuleContext<double> context, 
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // TODO: Create AutoMapper configuration for the context-to-message conversion
            var message = new NetlinkPointNotificationMessage();
            message.SourceKey = context.SourceKey;
            message.CurrentValue = context.CurrentValue;
            message.PreviousValue = context.LastValue;
            message.PointId = context.PointId;
            message.NotificationType = CurrentStateType.AnalogHighAlarm;
            message.PointTimestampUtc = context.LastReceiveUtc;
        }
    }
}