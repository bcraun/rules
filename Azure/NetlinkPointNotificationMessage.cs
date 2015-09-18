using System;

namespace ConsoleApplication1
{
    public class NetlinkPointNotificationMessage : INetlinkServiceBusMessage
    {
        public object SourceKey { get; set; }
        public CurrentStateType NotificationType { get; set; }
        public string CorrelationId { get; }
        public DateTime MessageTimestampUtc { get; }
        public int PointId { get; set; }
        public DateTime PointTimestampUtc { get; set; }
        public dynamic CurrentValue { get; set; }
        public dynamic PreviousValue { get; set; }

        public NetlinkPointNotificationMessage()
        {
            CorrelationId = Guid.NewGuid().ToString("N");
            MessageTimestampUtc = DateTime.UtcNow;
        }
    }
}