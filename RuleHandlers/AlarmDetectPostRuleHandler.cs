
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class AlarmDetectPostRuleHandler : 
        IPostRuleHandler<AlarmDetectRuleExecutor, RuleExecutionResponse>
    {
        public async Task HandleAsync(
            AlarmDetectRuleExecutor alarmDetectRuleExecutor,
            IRuleContext context,
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Was the last value and current value the same? 
            // Even if we detected in alarm, we don't want to keep sending 
            // same notification states
            if (context.CurrentValue != context.LastValue)
            {
                // Is the alarm enabled
                if (context.BooleanAlarmEnabled)
                {
                    // Are notifications enabled for the point
                    if ((context.NotificationLevel > 0) && (
                        ruleExecutionResponse.CurrentState == CurrentStateType.DigitalIntoAlarmTransition ||
                        ruleExecutionResponse.CurrentState == CurrentStateType.DigitalOutOfAlarmTransition))
                    {
                        // TODO: Create AutoMapper configuration for the context-to-message conversion
                        var message = new NetlinkPointNotificationMessage
                        {
                            SourceKey = context.SourceKey,
                            CurrentValue = context.CurrentValue,
                            PreviousValue = context.LastValue,
                            PointId = context.PointId,
                            NotificationType = ruleExecutionResponse.CurrentState,
                            PointTimestampUtc = context.LastReceiveUtc
                        };

                        var client = serviceBusClient.CreateClientAsync().Result;
                        await client.SendAsync(message);

//                    NetlinkPointNotificationMessage msg;
//                    do
//                    {
//                        msg = (NetlinkPointNotificationMessage)await client.ReceiveAsync(null);
//                        if (msg != null)
//                        {
//                            Console.WriteLine(msg.CorrelationId);
//                            Console.WriteLine(msg.MessageTimestampUtc);
//                        }
//                    } while (msg != null);
//
//                    context.Event.Set();
                    }
                }
            }
        }
    }
}