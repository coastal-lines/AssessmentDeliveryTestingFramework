using TestingFramework.Core.Logging.Adapters;

namespace TestingFramework.Core.Logging
{
    public static class Logger
    {
        private static readonly ILoggerAdapter loggerAdapter = new SerilogAdapter();

        public static void LogInformation(string message)
        {
            loggerAdapter.LogInformation(message);
        }

        public static void LogError(string message, Exception ex)
        {
            loggerAdapter.LogError(message, ex);
        }
    }
}
