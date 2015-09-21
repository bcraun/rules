using System;

namespace ConsoleApplication1
{
    public interface IRuleContext
    {
        object SourceKey { get; set; }

        int PointId { get; set; }

        object CurrentValue { get; set; }

        object LastValue { get; set; }

        bool IsEnabled { get; set; }

        bool HighAlarmEnabled { get; set; }

        double HighAlarmValue { get; set; }

        bool LowAlarmEnabled { get; set; }

        double LowAlarmValue { get; set; }

        bool HighWarningEnabled { get; set; }

        double HighWarningValue { get; set; }

        bool LowWarningEnabled { get; set; }

        double LowWarningValue { get; set; }

        int NotificationLevel { get; set; }

        DateTime LastReceiveUtc { get; set; }

        int BooleanAlarmState { get; set; }

        bool BooleanAlarmEnabled { get; set; }
    }
}