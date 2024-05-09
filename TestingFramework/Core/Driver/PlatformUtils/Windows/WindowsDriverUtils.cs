using TestingFramework.Core.Logging;
using TestingFramework.Core.TestManagement;
using TestingFramework.Utils.System;
using OpenQA.Selenium.Appium.Windows;

namespace TestingFramework.Core.Driver.PlatformUtils.Windows
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
                Logger.LogError(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);
            }

            try
            {
                TearDownAllDrivers();
            }
            catch (ArgumentException ex)
            {
                Logger.LogError(ex.Message, ex);
            }
        }

        public void TearDownAllDrivers()
        {
            TerminateProcess("winappdriver");
        }
    }
}
