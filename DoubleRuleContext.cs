using System.Runtime.Serialization;

namespace ConsoleApplication1
{
    [DataContract]
    public class DoubleRuleContext : IRuleContext
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public double CurrentValue { get; set; }

        [DataMember]
        public double PreviousValue { get; set; }

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
        public bool AlarmOnZero { get; set; }

        [DataMember]
        public bool AlarmOnOne { get; set; }

        [DataMember]
        public bool NotifyOnZero { get; set; }

        [DataMember]
        public bool NotifyOnOne { get; set; }
    }
}