using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Utils.System;
using OpenQA.Selenium.Appium.Windows;

namespace AssessmentDeliveryTestingFramework.Core.Driver.PlatformUtils.Windows
{
    public sealed class WindowsDriverUtils : IPlatformDriverUtils
    {
        private WindowsSystemUtils _processUtils;

        public WindowsDriverUtils() 
        {
            _processUtils = new WindowsSystemUtils();
        }

        public List<int> GetDriversProcessesId(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return _processUtils.GetListProcessesId("chromedriver");

                case BrowserType.Firefox:
                    return _processUtils.GetListProcessesId("geckodriver");

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }

        public void TerminateProcess(string processName)
        {
            _processUtils.CloseAllProcesses(processName);
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
    }
}
