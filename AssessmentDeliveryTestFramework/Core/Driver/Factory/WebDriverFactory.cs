using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using AssessmentDeliveryTestingFramework.Core.Logging;
using AssessmentDeliveryTestingFramework.Utils;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class WebDriverFactory
    {
        private void AddChromeExtension(ref ChromeOptions options, string chromeCRXExtensionPath)
        {
            options.AddExtension(chromeCRXExtensionPath);
        }

        public IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("log-level=0");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Driver, LogLevel.All);

            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("log.level", "info");

            return new FirefoxDriver(options);
        }

        public IWebDriver CreateRemoteFirefoxDriver()
        {
            var options = new FirefoxOptions();
            return new RemoteWebDriver(new Uri($"http://{ConfigurationManager.GetConfigurationModel().Web.RemoteUrl}:{ConfigurationManager.GetConfigurationModel().Web.RemotePort}"), options);
        }

        public IWebDriver CreateCustomElectronBrowser()
        {
            var driverPath = Path.Combine(DirectoryUtils.GetCustomDriversPath(), "Chrome116");
            var binaryLocationPath = Path.Combine(WindowsEnvironmentUtils.GetUserSystemPath(), ConfigurationManager.GetConfigurationModel().Web.MinBrowser.BinaryLocation);

            var options = new ChromeOptions();
            options.BinaryLocation = binaryLocationPath;
            options.AddWindowType("webview");

            var service = ChromeDriverService.CreateDefaultService(driverPath);

            return new ChromeDriver(service, options);
        }
    }
}
