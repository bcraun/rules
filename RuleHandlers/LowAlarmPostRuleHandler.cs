using System;

namespace ConsoleApplication1
{
    public class LowAlarmPostRuleHandler : 
        IPostRuleHandler<LowAlarmRuleExecutor, RuleExecutionResponse>
    {
        public void Handle(
            LowAlarmRuleExecutor lowAlarmRuleExecutor, 
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