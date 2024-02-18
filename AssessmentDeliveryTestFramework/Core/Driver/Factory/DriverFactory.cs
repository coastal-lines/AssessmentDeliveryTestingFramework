using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers.CustomContainers;
using AssessmentDeliveryTestingFramework.Core.Logging;
using OpenQA.Selenium.Firefox;

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
                    MobileDriverFactory.StartAppiumService();
                    MobileDriverFactory.StartAndroidEmulator();
                    return new MobileAndroidDriverContainer(MobileDriverFactory.CreateMobileDriver(), "android", "android", deviceType);

                default:
                    string errorMessage = $"Device {deviceType} is not supported.";
                    Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                    throw new NotSupportedException(errorMessage);
            }
        }

        public IDriverContainer CreateDesktopDriverContainer(string testType, string applicationPath)
        {
            switch (testType)
            {
                case TestType.Desktop:
                    WindowsDriverFactory.StartAppiumService();
                    return new DesktopDriverContainer(WindowsDriverFactory.CreateWindowsDriver("Windows", applicationPath, "WindowsPC", "Windows"), 
                        "desktop_test_name", 
                        ConfigurationManager.GetConfigurationModel().Desktop.Platform, 
                        "Windows");
                default:
                    string errorMessage = $"Test type {testType} is not supported.";
                    Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                    throw new NotSupportedException(errorMessage);
            }
        }

        public IDriverContainer CreateBrowserRemoteDriverContainer(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    return new BrowserDriverContainer(WebDriverFactory.CreateRemoteFirefoxDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                default:
                    string errorMessage = $"Browser type {browserType} is not supported.";
                    Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                    throw new NotSupportedException(errorMessage);
            }
        }

        public IDriverContainer CreateBrowserDriverContainer(string browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return new BrowserDriverContainer(WebDriverFactory.CreateChromeDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                case BrowserType.Firefox:
                    var driver = WebDriverFactory.GetWebDriverByDriverManagerSolution<FirefoxDriver>("firefox");
                    return new BrowserDriverContainer(driver, browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");
                    //return new BrowserDriverContainer(WebDriverFactory.CreateFirefoxDriver(), browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                case BrowserType.Min:
                    var minDriver = WebDriverFactory.CreateElectronBasedBrowserMin();
                    return new MinBrowserDriverContainer(new MinBrowserFeatures(minDriver), minDriver, browserType + "_count_", ConfigurationManager.GetConfigurationModel().Framework.Platform, browserType, "Web");

                default:
                    string errorMessage = $"Browser type {browserType} is not supported.";
                    Logger.LogError(errorMessage, new NotSupportedException(errorMessage));
                    throw new NotSupportedException(errorMessage);
            }
        }
    }
}