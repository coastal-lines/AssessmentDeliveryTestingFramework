namespace TestingFramework.Core.Driver.DriverContainers
{
    public interface IDriverContainer
    {
        object Driver { get; }
        string Name { get; }
        string Platform { get; }
        string CurrentTestType { get; }
    }
}
