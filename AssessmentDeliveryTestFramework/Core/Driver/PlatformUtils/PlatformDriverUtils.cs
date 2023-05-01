using AssessmentDeliveryTestingFramework.Core.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils
{
    public class PlatformDriverUtils
    {
        private IPlatformDriverUtils _driverUtils;
        private List<IDriverContainer> _sessionDrivers;

        public PlatformDriverUtils(IPlatformDriverUtils driverUtils)
        {
            _driverUtils = driverUtils;
        }

        public PlatformDriverUtils UpdateSessionDrivers(List<IDriverContainer> sessionDrivers)
        {
            this._sessionDrivers = sessionDrivers;
            return this;
        }

        public void TerminateProcess(string processName)
        {
            _driverUtils.TerminateProcess(processName);
        }

        public List<int> GetDriversProcessesId(string browserType)
        {
            return _driverUtils.GetDriversProcessesId(browserType);
        }

        public void TearDownDriver(string browserType)
        {
            
        }
    }
}
