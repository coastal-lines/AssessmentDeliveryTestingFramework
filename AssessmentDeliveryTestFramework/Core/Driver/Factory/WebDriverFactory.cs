using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
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

        public IWebDriver CreateChromeDriver()
        {
                ChromeOptions options = new ChromeOptions();

                options.AddArgument("log-level=0");
                options.SetLoggingPreference(LogType.Browser, LogLevel.All);
                options.SetLoggingPreference(LogType.Driver, LogLevel.All);

                new DriverManager().SetUpDriver(
                    "https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/win64/chromedriver-win64.zip",
                    Path.Combine(Directory.GetCurrentDirectory(), "chromedriver.exe"),
                    "chromedriver.exe"
                );
            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("log.level", "info");

            //FirefoxDriverService service = FirefoxDriverService.CreateDefaultService();
            // service.DriverServicePath = Path.Combine(DirectoryUtils.GetCustomDriversPath(), ConfigurationManager.GetConfigurationModel().Web.FirefoxDriverPath).Replace("\\", "///") + "geckodriver.exe";
            //service.DriverServicePath = "c:\\Repos\\MyGit\\AssessmentDeliveryTestFramework\\AssessmentDeliveryTestFramework\\Files\\Files\\CustomDrivers\\GeckoBased\\Firefox034\\geckodriver.exe";
            //service.FirefoxBinaryPath = "c:\\Program Files\\Mozilla Firefox\\firefox.exe";

            //IWebDriver driver = new FirefoxDriver(service, options);
            IWebDriver driver = new FirefoxDriver(options);

            return driver;
        }

        public IWebDriver CreateRemoteFirefoxDriver()
        {
            var options = new FirefoxOptions();

            return new RemoteWebDriver(new Uri(
                $"http://{ConfigurationManager.GetConfigurationModel().Web.RemoteUrl}:{ConfigurationManager.GetConfigurationModel().Web.RemotePort}"),
                options);
        }

        //TODO - the best example for Selenium 3 demo support!!!
        public IWebDriver CreateElectronBasedBrowserOhHai()
        {
            var options = new ChromeOptions();

            string chromeDriverPath = "\\Core\\Driver\\CustomDrivers\\ChromiumBased\\Chrome89\\";

            options.BinaryLocation = "\\OhHai Browser\\OhHai Browser.exe";
            options.AddWindowType("webview");

            return new ChromeDriver(options);
        }

        public IWebDriver CreateElectronBasedBrowserMin()
        {
            //var userSystemFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var options = new ChromeOptions();

            string chromeDriverPath = "\\AssessmentDeliveryTestFramework\\Files\\CustomDrivers\\ChromiumBased\\Chrome116\\";
            options.BinaryLocation = "\\AppData\\Local\\min\\app-1.29.0\\min.exe";
            options.AddWindowType("webview");

            return new ChromeDriver(chromeDriverPath, options);
        }
    }
}
