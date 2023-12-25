using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Utils;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils.Windows
{
    public class WindowsDriverUtils : IPlatformDriverUtils
    {
        private WindowsPlatformUtils _windowsPlatformUtils;

        public WindowsDriverUtils()
        {
            _windowsPlatformUtils = new WindowsPlatformUtils();
        }

        public List<int> GetDriversProcessesId(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return _windowsPlatformUtils.GetProcessByName("chromedriver").Select(process => process.Id).ToList();

                case BrowserType.Firefox:
                    return _windowsPlatformUtils.GetProcessByName("geckodriver").Select(process => process.Id).ToList();

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }

        public void TearDownAllDrivers()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("geckodriver"))
            {
                process.Kill();
            }
        }

        //TODO
        public void TearDownDriver(List<IDriverContainer> sessionDrivers, string browserType)
        {
            throw new NotImplementedException();
        }

        public void TerminateProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }

        /*
        public void TearDownDriver(List<DriverContainer> sessionDrivers, string browserType = BrowserType.Chrome)
        {
            foreach (DriverContainer driverContainer in sessionDrivers)
            {
                if (driverContainer.BrowserType == browserType)
                {
                    try
                    {
                        driverContainer.Driver.Quit();
                    }
                    catch (ObjectDisposedException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    try
                    {
                        //Process.GetProcessById(driverContainer.DriverProcessId).Kill();
                        TearDownAllDrivers();
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        */

        /*
        public int GetDriverId(List<DriverContainer> sessionDrivers, List<int> driversIdBefore, string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var driversChromeIdAfter = GetDriversProcessesId(browserType);
                    var newChromeId = driversChromeIdAfter.Except(driversIdBefore).ToList();
                    var currentDriversProcessIds = sessionDrivers.Where(driver => driver.BrowserType.Contains("chromedriver")).Select(driver => driver.DriverProcessId).ToList();
                    var newChromeId2 = newChromeId.Except(currentDriversProcessIds).ToList();


                    if (newChromeId.Count != 0)
                    {
                        return newChromeId[0];
                    }
                    else
                    {
                        throw new InvalidOperationException("More than one new Chrome process were found.");
                    }


                case BrowserType.Firefox:
                    //var currentFirefoxProcessIds = GetDriversProcessesId(browserType);
                    var currentFirefoxDriversProcessIds = sessionDrivers.Where(driver => driver.BrowserType.Contains("geckodriver")).Select(driver => driver.DriverProcessId).ToList();

                    var newFirefoxId = driversIdBefore.Except(currentFirefoxDriversProcessIds).ToList();
                    if (newFirefoxId.Count == 1)
                    {
                        return Process.GetProcessesByName("geckodriver")[0].Id;
                    }
                    else
                    {
                        throw new InvalidOperationException("More than one new Chrome process were found.");
                    }

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }
        */
    }
}
