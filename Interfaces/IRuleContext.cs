using System;

namespace ConsoleApplication1
{
    public interface IRuleContext<T> where T: struct
    {
        object SourceKey { get; set; }

        int PointId { get; set; }

        T CurrentValue { get; set; }

        T LastValue { get; set; }

        bool IsEnabled { get; set; }

        bool HighAlarmEnabled { get; set; }

        T HighAlarmValue { get; set; }

        bool LowAlarmEnabled { get; set; }

        T LowAlarmValue { get; set; }

        bool HighWarningEnabled { get; set; }

        T HighWarningValue { get; set; }

        bool LowWarningEnabled { get; set; }

        T LowWarningValue { get; set; }

        int NotificationLevel { get; set; }

        DateTime LastReceiveUtc { get; set; }

        int BooleanAlarmState { get; set; }

        bool BooleanAlarmEnabled { get; set; }
    }
}