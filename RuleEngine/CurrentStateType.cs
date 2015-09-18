namespace ConsoleApplication1
{
    public enum CurrentStateType
    {
        Normal = 0,
        DigitalIntoAlarmTransition,
        DigitalOutOfAlarmTransition,
        AnalogLowWarning,
        AnalogHighWarning,
        AnalogLowAlarm,
        AnalogHighAlarm,
        PointDisabled
    }
}