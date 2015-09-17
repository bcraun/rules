namespace ConsoleApplication1
{
    public enum CurrentStateType
    {
        Normal = 0,
        OutOfAlarm,
        Low,
        High,
        LowWarning,
        HighWarning,
        LowAlarm,
        HighAlarm,
        DigitalRisingEdgeDetect,
        DigitalFallingEdgeDetect,
        Disabled
    }
}