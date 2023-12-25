using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Utils
{
    public class WindowsPlatformUtils
    {
        public Process[] GetProcessByName(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        public void KillProcessByName(string processName)
        {
            GetProcessByName(processName).FirstOrDefault().Kill();
        }
    }
}