using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using System.Diagnostics;
using AssessmentDeliveryTestingFramework.Utils.System;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
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
            //var currentProcesses = new List<Process>(Process.GetProcesses().Where(p => p.ProcessName.Equals("WinAppDriver")));
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
                    //currentProcesses = new List<Process>(Process.GetProcesses().Where(p => p.ProcessName.Equals("WinAppDriver")));
                    currentProcesses = _windowsSystemUtils.GetListProcessesByName("WinAppDriver");
                    if (currentProcesses.Count > 0)
                    {
                        stopWatch.Stop();
                        break;
                    }
                }

                stopWatch.Stop();
                Thread.Sleep(8000);
            }
        }

        public static void StartWinAppDriver()
        {
            //Also work fine
            /*
            //string strCmdText = "/C appium -a 127.0.0.1 -p 4723";
            var appiumServer = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .UsingDriverExecutable(new FileInfo(@"C:\Program Files\nodejs\node.exe"))
                .WithAppiumJS(new FileInfo(@"\AppData\Roaming\npm\node_modules\appium\build\lib\main.js"))
                .WithStartUpTimeOut(TimeSpan.FromMinutes(3))
                .Build();

            appiumServer.Start();
            */

            var appiumServer = new AppiumServiceBuilder();
            var appiumOptions = new OptionCollector();
            appiumServer.WithArguments(appiumOptions);
            //builder.WithLogFile(new FileInfo(@"MobileTestsDemo\appium_log.txt"));
            var service = appiumServer.Build();
            service.Start();
        }

        public WindowsDriver CreateWindowsDriver(string automationName = "Windows", string applicationPath = "Root", string deviceName = "WindowsPC", string platformName = "Windows")
        {
            WindowsDriver driver = null;

            var appCapabilities = new AppiumOptions();
            appCapabilities.AutomationName = automationName;
            //appCapabilities.App = "C:\\Program Files (x86)\\Media Freeware\\Free Quiz Maker\\FreeQuizMaker.exe";
            appCapabilities.App = applicationPath;
            appCapabilities.DeviceName = deviceName;
            appCapabilities.PlatformName = platformName;
            var driverUrl = new Uri("http://127.0.0.1:4723");

            try
            {
                driver = new WindowsDriver(driverUrl, appCapabilities);
            }
            catch (WebDriverArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Previous 'winappdriver' process was not closed.");
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
            /*
            var currentProcesses = new List<Process>(Process.GetProcesses().Where(p => p.ProcessName.Equals(browserProcessName)));
            var userProcess = currentProcesses.Where(process => process.MainWindowHandle.ToString() != "0" && process.MainWindowTitle.ToString().Contains(windowTitle)).ToList();
            var appTopLevelWindowHandle = userProcess[0].MainWindowHandle;
            var appTopLevelWindowHandleHex = appTopLevelWindowHandle.ToString("x");
            */

            var appTopLevelWindowHandleHex = _windowsSystemUtils.GetApplicationTopLevelWindowHandleHex(browserProcessName, windowTitle);

            var builder = new AppiumServiceBuilder();
            KeyValuePair<string, string> arguments = new KeyValuePair<string, string>("--use-plugins", "images");
            builder.WithArguments(new OptionCollector().AddArguments(arguments));
            builder.WithLogFile(new FileInfo(@"appium_log.txt"));
            var service = builder.Build();
            service.Start();

            var serverUri = new Uri("http://127.0.0.1:4723");
            var appCapabilities = new AppiumOptions();
            appCapabilities.PlatformName = platformName;
            appCapabilities.AutomationName = automationName;
            appCapabilities.AddAdditionalAppiumOption("appTopLevelWindow", appTopLevelWindowHandleHex);
            appCapabilities.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            appCapabilities.AddAdditionalAppiumOption("newCommandTimeout", 10000);

            //Wait few seconds for NodeJS
            Thread.Sleep(3000);

            //WindowsDriver driver = null;

            try
            {
                return new WindowsDriver(serverUri, appCapabilities, TimeSpan.FromSeconds(300));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                Console.WriteLine("Additional Windows driver was not started.");

                throw new Exception();
            }
        }
    }
}
