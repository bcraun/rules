namespace ConsoleApplication1
{
    class ServiceFabricPointConfigurationProvider : IPointConfigurationProvider
    {
        public PointConfiguration GetPointConfiguration(string pointId)
        {
            // TODO: Call the point actor
            return new PointConfiguration();
        }
    }
}