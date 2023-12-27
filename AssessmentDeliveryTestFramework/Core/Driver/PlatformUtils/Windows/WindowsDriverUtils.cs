using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Utils;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils.Windows
{
    public sealed class WindowsDriverUtils : IPlatformDriverUtils
    {
        private Process[] GetProcessByName(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        public List<int> GetDriversProcessesId(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetProcessByName("chromedriver").Select(process => process.Id).ToList();

                case BrowserType.Firefox:
                    return GetProcessByName("geckodriver").Select(process => process.Id).ToList();

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }

        public void TerminateProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }

        public void TearDownWindowsDriver(WindowsDriver driver, string currentTestType = "Windows")
        {
            try
            {
                driver.Quit();
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                TearDownAllDrivers();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void TearDownAllDrivers()
        {
            TerminateProcess("winappdriver");
        }

        public void TearDownWebDriver(List<IDriverContainer> sessionDrivers, string browserType)
        {
            throw new NotImplementedException();
        }
    }
}
