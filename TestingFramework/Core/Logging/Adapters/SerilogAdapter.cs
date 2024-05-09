using TestingFramework.Utils;
using Serilog;

namespace TestingFramework.Core.Logging.Adapters
{
    public class SerilogAdapter : ILoggerAdapter
    {
        private static readonly Lazy<ILogger> logger = new Lazy<ILogger>(CreateLogger);


        /// <summary>
        /// Serilog logger initialization
        /// </summary>
        private static ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(DirectoryUtils.GetLogFilePath(), outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        public void LogInformation(string message)
        {
            logger.Value.Information(message);
        }

        public void LogError(string message, Exception ex)
        {
            logger.Value.Error(ex, message);
        }
    }
}
