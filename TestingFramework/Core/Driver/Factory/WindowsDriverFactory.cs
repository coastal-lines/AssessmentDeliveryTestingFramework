using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System.Diagnostics;
using TestingFramework.Utils.System;
using TestingFramework.Utils;
using TestingFramework.Core.Utils.Config;
using TestingFramework.Core.Logging;

namespace TestingFramework.Core.Driver.Factory
{
    public sealed class WindowsDriverFactory
    {
        private WindowsSystemUtils _windowsSystemUtils;

        public WindowsDriverFactory() 
        {
            _windowsSystemUtils = new WindowsSystemUtils();
        }

        /// <summary>
        /// For Appium 4.4.5 and Selenium3 only!
        /// </summary>
        [Obsolete]
        public void StartWinAppDriverForAppium1()
        {
            var currentProcesses = _windowsSystemUtils.GetListProcessesByName("WinAppDriver");

            if (currentProcesses.Count == 0)
            {
                // Must be run as Administrator - in other case winappdriver doesn't see any app
                _windowsSystemUtils.StartProcess("\\WinAppDriver\\WinAppDriver.exe");

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.Elapsed.Seconds < 10)
                {
                    Thread.Sleep(500);
                    currentProcesses = _windowsSystemUtils.GetListProcessesByName("WinAppDriver");
                    if (currentProcesses.Count > 0)
                    {
                        stopWatch.Stop();
                        break;
                    }
                }

                stopWatch.Stop();
            }
        }

        public void StartAppiumService()
        {
            var appiumServiceBuilder = new AppiumServiceBuilder();
            appiumServiceBuilder.WithLogFile(new FileInfo(Path.Join(DirectoryUtils.GetTemporaryResourcesPath(), $"winappdriver_log_{DateTimeUtils.GetCurrentDate()}.txt")));

            var appiumOptions = new OptionCollector();
            appiumServiceBuilder.WithArguments(appiumOptions);

            var appiumService = appiumServiceBuilder.Build();
            appiumService.Start();

            _windowsSystemUtils.WaitProcessStarted("nodejs");
        }

        private void StartAppiumServiceWithImagePlugin()
        {
            var appiumServiceBuilder = new AppiumServiceBuilder();
            KeyValuePair<string, string> arguments = new KeyValuePair<string, string>("--use-plugins", "images");
            appiumServiceBuilder.WithArguments(new OptionCollector().AddArguments(arguments));
            appiumServiceBuilder.WithLogFile(new FileInfo(Path.Join(DirectoryUtils.GetTemporaryResourcesPath(), $"additional_windows_driver_log_{DateTimeUtils.GetCurrentDate()}.txt")));
            
            var service = appiumServiceBuilder.Build();
            service.Start();

            _windowsSystemUtils.WaitProcessStarted("nodejs");
        }

        public WindowsDriver CreateWindowsDriver(string automationName = "Windows", string applicationPath = "Root", string deviceName = "WindowsPC", string platformName = "Windows")
        {
            WindowsDriver driver = null;

            var appCapabilities = new AppiumOptions();
            appCapabilities.AutomationName = automationName;
            appCapabilities.App = applicationPath;
            appCapabilities.DeviceName = deviceName;
            appCapabilities.PlatformName = platformName;

            var driverUrl = new Uri($"http://{ConfigurationManager.GetConfigurationModel().Desktop.Host}:{ConfigurationManager.GetConfigurationModel().Desktop.Port}");

            try
            {
                driver = new WindowsDriver(driverUrl, appCapabilities);
            }
            catch (WebDriverArgumentException ex)
            {
                Logger.LogInformation("Previous 'winappdriver' process was not closed.");
                Logger.LogError($"Windows driver was not started. Url is {driverUrl}, application is {applicationPath}", ex);
                throw ex;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            return driver;
        }


        /// <summary>
        /// In this case 'WinAppDriver' will starts automatically.
        /// Don't try to run manually, Image plugin will not works correctly.
        /// </summary>
        public WindowsDriver CreateWindowsDriverForBrowserConnecting(string browserProcessName, string windowTitle, string platformName = "Windows", string automationName = "Windows")
        {
            var appTopLevelWindowHandleHex = _windowsSystemUtils.GetApplicationTopLevelWindowHandleHex(browserProcessName, windowTitle);

            StartAppiumServiceWithImagePlugin();

            var serverUri = new Uri($"http://{ConfigurationManager.GetConfigurationModel().Desktop.Host}:{ConfigurationManager.GetConfigurationModel().Desktop.Port}/");
            var appCapabilities = new AppiumOptions();
            appCapabilities.PlatformName = platformName;
            appCapabilities.AutomationName = automationName;
            appCapabilities.AddAdditionalAppiumOption("appTopLevelWindow", appTopLevelWindowHandleHex);
            appCapabilities.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            appCapabilities.AddAdditionalAppiumOption("newCommandTimeout", 10000);

            //Wait few seconds for NodeJS
            _windowsSystemUtils.WaitProcessStarted("nodejs");

            try
            {
                return new WindowsDriver(serverUri, appCapabilities, TimeSpan.FromSeconds(300));
            }
            catch (Exception ex)
            {
                Logger.LogError("Additional Windows driver was not started.", ex);
                throw;
            }
        }
    }
}
