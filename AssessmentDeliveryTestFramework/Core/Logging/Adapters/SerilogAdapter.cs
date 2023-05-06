using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestFramework.Core.Logging.Adapters
{
    using Serilog;

    public class SerilogAdapter : ILoggerAdapter
    {
        private readonly ILogger logger;

        public SerilogAdapter()
        {
            // Initialize your Serilog logger here
            this.logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }

        public void LogInformation(string message)
        {
            this.logger.Information(message);
        }

        public void LogError(string message, Exception ex)
        {
            this.logger.Error(ex, message);
        }
        // Implement other log methods
    }
}
