namespace ConsoleApplication1
{
    public interface IPointConfigurationProvider
    {
        PointConfiguration GetPointConfiguration(string pointId);
    }
}