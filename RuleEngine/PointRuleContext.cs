using System;
using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    [DataContract]
    public class PointRuleContext : IRuleContext<double>
    {
        [DataMember]
        public object SourceKey { get; set; }

        [DataMember]
        public int PointId { get; set; }

        [DataMember]
        public bool InAlarm { get; set; }

        [DataMember]
        public double CurrentValue { get; set; }

        [DataMember]
        public double LastValue { get; set; }

        [DataMember]
        public bool IsEnabled { get; set; }

        [DataMember]
        public bool HighAlarmEnabled { get; set; }

        [DataMember]
        public double HighAlarmValue { get; set; }

        [DataMember]
        public bool LowAlarmEnabled { get; set; }

        [DataMember]
        public double LowAlarmValue { get; set; }

        [DataMember]
        public bool HighWarningEnabled { get; set; }

        [DataMember]
        public double HighWarningValue { get; set; }

        [DataMember]
        public bool LowWarningEnabled { get; set; }

        [DataMember]
        public double LowWarningValue { get; set; }

        [DataMember]
        public int NotificationLevel { get; set; }

        [DataMember]
        public DateTime LastReceiveUtc { get; set; }

        [DataMember]
        public int BooleanAlarmState { get; set; }

        [DataMember]
        public bool BooleanAlarmEnabled { get; set; }
    }
}