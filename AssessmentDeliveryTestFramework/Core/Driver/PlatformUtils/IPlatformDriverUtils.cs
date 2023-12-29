using AssessmentDeliveryTestingFramework.Core.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils
{
    public interface IPlatformDriverUtils
    {
        void TerminateProcess(string processName);

        List<int> GetDriversProcessesId(string browserType);
    }
}