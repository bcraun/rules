namespace ConsoleApplication1
{
    public interface IRuleContext<T> where T: struct
    {
        string Key { get; set; }

        T CurrentValue { get; set; }

        T PreviousValue { get; set; }

        bool IsEnabled { get; set; }

        bool HighAlarmEnabled { get; set; }

        T HighAlarmValue { get; set; }

        bool LowAlarmEnabled { get; set; }

        T LowAlarmValue { get; set; }

        bool HighWarningEnabled { get; set; }

        T HighWarningValue { get; set; }

        bool LowWarningEnabled { get; set; }

        T LowWarningValue { get; set; }

        bool AlarmOnZero { get; set; }

        bool AlarmOnOne { get; set; }

        bool NotifyOnZero { get; set; }

        bool NotifyOnOne { get; set; }

        T ScaledValue { get; set; }
    }
}