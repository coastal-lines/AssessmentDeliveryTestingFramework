﻿using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class WindowsDriverFactory
    {
        //Appium 4.4.5
        /*
        public void StartWinAppDriver()
        {
            var currentProcesses = new List<Process>(Process.GetProcesses().Where(p => p.ProcessName.Equals("WinAppDriver")));

            if (currentProcesses.Count == 0)
            {
                 // Must be run as Administrator - in other case winappdriver doesn't see any app
                var pathWinAppDriver = "\\WinAppDriver\\WinAppDriver.exe";

                Process p = new Process();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.FileName = pathWinAppDriver;
                p.StartInfo.Verb = "runas";
                p.Start();

                //p.Start(pathWinAppDriver);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                while (stopWatch.Elapsed.Seconds < 10)
                {
                    Thread.Sleep(500);
                    currentProcesses = new List<Process>(Process.GetProcesses().Where(p => p.ProcessName.Equals("WinAppDriver")));
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
        */

        //Appium 4.4.5
        /*
        public WindowsDriver<IWebElement> CreateWindowsDriver()
        {
            AppiumOptions Options = new AppiumOptions();
            Options.AddAdditionalCapability("app", "\\Free Quiz Maker\\FreeQuizMaker.exe");
            Options.AddAdditionalCapability("deviceName", "WindowsPC");
            Options.AddAdditionalCapability("platformName", "Windows");
            //var DesktopSession = new WindowsDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), Options);

            var driverUrl = "http://127.0.0.1:4723";

            var applicationSession = new WindowsDriver<IWebElement>(new Uri(driverUrl), Options);
            applicationSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            return applicationSession;
        }
        */

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
    }
}
