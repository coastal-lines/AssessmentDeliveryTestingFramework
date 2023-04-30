using AssessmentDeliveryTestingFramework.Core.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils
{
    public interface IPlatformDriverUtils
    {
        void TearDownDriver(List<IDriverContainer> sessionDrivers, string browserType);

        List<int> GetDriversProcessesId(string browserType);

        void TerminateProcess(string processName);
    }
}