using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class WebDriverFactory
    {
        private void AddChromeExtension(ref ChromeOptions options, string chromeCRXExtensionPath)
        {
            options.AddExtension(chromeCRXExtensionPath);
        }

        /*
        public T GetWebDriverByDriverManagerSolution<T>(string driverType)
        {
            //INFO = 0, 
            //WARNING = 1, 
            //LOG_ERROR = 2, 
            //LOG_FATAL = 3.

            switch (driverType) 
            {
                case "chrome":
                    var options = new ChromeOptions();

                    options.AddArgument("log-level=0");
                    options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                    options.SetLoggingPreference(LogType.Driver, LogLevel.All);

                    new DriverManager().SetUpDriver(
                        "https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/win64/chromedriver-win64.zip",
                        Path.Combine(Directory.GetCurrentDirectory(), "chromedriver.exe"),
                        "chromedriver.exe"
                    );

                    return (T)(object)new ChromeDriver(options);

                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());

                    return (T)(object)new FirefoxDriver();

                default:
                    string errorMessage = $"Driver '{driverType}' not supported";
                    Logger.LogError(errorMessage, new ArgumentNullException(errorMessage));
                    throw new Exception(errorMessage);
            }
        }
        */

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

        public IWebDriver CreateCustomElectronBrowser(string binaryLocationPath, string driverPath)
        {
            var options = new ChromeOptions();
            options.BinaryLocation = binaryLocationPath;
            options.AddWindowType("webview");

            var service = ChromeDriverService.CreateDefaultService(driverPath);

            return new ChromeDriver(service, options);
        }
    }
}
