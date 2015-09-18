using System;

namespace ConsoleApplication1
{
    public interface INetlinkServiceBusMessage
    {
        string CorrelationId { get; }
        DateTime MessageTimestampUtc { get; }
    }
}