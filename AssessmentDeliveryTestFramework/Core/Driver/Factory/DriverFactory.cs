using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Diagnostics;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using OpenQA.Selenium.Remote;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public class DriverFactory
    {
        public WindowsDriverFactory WindowsDriverFactory { get; private set; } = new WindowsDriverFactory();

        public MobileDriverFactory MobileDriverFactory { get; private set; } = new MobileDriverFactory();

        public WebDriverFactory WebDriverFactory { get; private set; } = new WebDriverFactory();


        public IDriverContainer CreateMobileDriverContainer(string deviceType)
        {
            switch (deviceType)
            {
                case "Android":
                    //MobileDriverFactory.StartAndroidEmulator();
                    return new MobileAndroidDriverContainer(MobileDriverFactory.CreateMobileDriver(), "android", "android", deviceType);

                default:
                    throw new NotSupportedException($"Device {deviceType} is not supported.");
            }
        }

        public IDriverContainer CreateDesktopDriverContainer(string testType)
        {
            switch (testType)
            {
                case TestType.Desktop:
                    WindowsDriverFactory.StartWinAppDriver();
                    //return new DesktopDriverContainer(WindowsDriverFactory.CreateWindowsDriver(), testType + "_count_", ConfigManager.Config.Platform, "Windows");
                    return new DesktopDriverContainer(WindowsDriverFactory.CreateWindowsDriver(), "desktop_test_name", ConfigurationManager.GetConfigurationModel().Desktop.Platform, "Windows");
                default:
                    throw new NotSupportedException($"Test type {testType} is not supported.");
            }
        }

        public IDriverContainer CreateBrowserRemoteDriverContainer(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    return new BrowserDriverContainer(WebDriverFactory.CreateRemoteFirefoxDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }

        public IDriverContainer CreateBrowserDriverContainer(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new BrowserDriverContainer(WebDriverFactory.CreateChromeDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                case BrowserType.Firefox:
                    //return new BrowserDriverContainer(CreateFirefoxDriver(), browserType + "_count_", ConfigManager.Config.Platform, browserType);
                    return new BrowserDriverContainer(WebDriverFactory.CreateFirefoxDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                //case BrowserType.ElectronBasedBrowserOhHai:
                //    return CreateElectronBasedBrowserOhHai();

                case BrowserType.Min:
                    var minDriver = WebDriverFactory.CreateElectronBasedBrowserMin();
                    //return new MinBrowserDriverContainer(new MinBrowserFeatures(minDriver), minDriver, browserType + "_count_", ConfigManager.Config.Platform, browserType);
                    return new MinBrowserDriverContainer(new MinBrowserFeatures(minDriver), minDriver, browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                default:
                    throw new NotSupportedException($"Browser type {browserType} is not supported.");
            }
        }
    }
}