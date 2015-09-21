using System;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    [JsonObject]
    public class NetlinkPointNotificationMessage : INetlinkServiceBusMessage
    {
        [JsonProperty("source_key")]
        public object SourceKey { get; set; }
        [JsonProperty("notification_type")]
        public CurrentStateType NotificationType { get; set; }
        [JsonProperty("correlation_id")]
        public string CorrelationId { get; }
        [JsonProperty("message_timestamp_utc")]
        public DateTime MessageTimestampUtc { get; }
        [JsonProperty("point_id")]
        public int PointId { get; set; }
        [JsonProperty("point_timestamp_utc")]
        public DateTime PointTimestampUtc { get; set; }
        [JsonProperty("current_value")]
        public dynamic CurrentValue { get; set; }
        [JsonProperty("previous_value")]
        public dynamic PreviousValue { get; set; }

        public NetlinkPointNotificationMessage()
        {
            CorrelationId = Guid.NewGuid().ToString("N");
            MessageTimestampUtc = DateTime.UtcNow;
        }
    }

//    class RootObject
//    {
//        [JsonProperty("results")]
//        public Results Results { get; set; }
//    }
//
//    class Results
//    {
//        [JsonProperty("jobcodes")]
//        public Dictionary<string, JobCode> JobCodes { get; set; }
//    }
//
//    class JobCode
//    {
//        [JsonProperty("_status_code")]
//        public string StatusCode { get; set; }
//        [JsonProperty("_status_message")]
//        public string StatusMessage { get; set; }
//        [JsonProperty("id")]
//        public string Id { get; set; }
//        [JsonProperty("name")]
//        public string Name { get; set; }
//    }
}