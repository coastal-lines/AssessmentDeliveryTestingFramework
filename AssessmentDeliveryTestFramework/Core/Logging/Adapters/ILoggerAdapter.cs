using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestFramework.Core.Logging.Adapters
{
    public interface ILoggerAdapter
    {
        void LogInformation(string message);

        void LogError(string message, Exception ex);
        // Add other log methods as needed
    }
}
