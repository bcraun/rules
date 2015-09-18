﻿using System;

namespace ConsoleApplication1
{
    public class RisingEdgePostRuleHandler : 
        IPostRuleHandler<RisingEdgeRuleExecutor, RuleExecutionResponse>
    {
        public async void Handle(
            RisingEdgeRuleExecutor fallingEdgeRuleExecutor,
            IRuleContext<double> context,
            RuleExecutionResponse ruleExecutionResponse,
            IServiceBusClient<IServiceBusQueueNameFactory, IServiceBusConnectionStringFactory, INetlinkServiceBusMessage> serviceBusClient)
        {
            // Is the alarm enabled
            if (context.BooleanAlarmEnabled)
            {
                // Are notifications enabled for the point
                if ((context.NotificationLevel > 0))
                {
                    // TODO: Create AutoMapper configuration for the context-to-message conversion
                    var message = new NetlinkPointNotificationMessage();
                    message.SourceKey = context.SourceKey;
                    message.CurrentValue = context.CurrentValue;
                    message.PreviousValue = context.LastValue;
                    message.PointId = context.PointId;
                    message.NotificationType = CurrentStateType.AnalogHighAlarm;
                    message.PointTimestampUtc = context.LastReceiveUtc;

                    var client = serviceBusClient.CreateClientAsync().Result;
                    await client.SendAsync(message);

                    NetlinkPointNotificationMessage msg;
                    do
                    {
                        msg = (NetlinkPointNotificationMessage)await client.ReceiveAsync(null);
                        if (msg != null)
                        {
                            Console.WriteLine(msg.CorrelationId);
                            Console.WriteLine(msg.MessageTimestampUtc);
                        }
                    } while (msg != null);

                    await client.CloseAsync();
                }
            }
        }
    }
}