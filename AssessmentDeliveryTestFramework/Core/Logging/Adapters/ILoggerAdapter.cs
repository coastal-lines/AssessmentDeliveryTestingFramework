namespace AssessmentDeliveryTestFramework.Core.Logging.Adapters
{
    public interface ILoggerAdapter
    {
        void LogInformation(string message);

        void LogError(string message, Exception ex);
    }
}
