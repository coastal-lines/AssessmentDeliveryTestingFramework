using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;

namespace AssessmentDeliveryTestingFramework.Core.Driver.Factory
{
    public sealed class WebDriverFactory
    {
        public IWebDriver CreateChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            /*
                INFO = 0, 
                WARNING = 1, 
                LOG_ERROR = 2, 
                LOG_FATAL = 3.
            */

            options.AddArgument("log-level=0");
            options.SetLoggingPreference(LogType.Browser, LogLevel.All);
            options.SetLoggingPreference(LogType.Driver, LogLevel.All);

            //string chromeDriverPath = "F:\\Data\\Work\\OwnProjects\\C#\\AssessmentDeliveryAutomation\\AssessmentDeliveryTestFramework\\Core\\Driver\\CustomDrivers\\ChromiumBased\\Chrome119\\";
            //return new ChromeDriver(chromeDriverPath, options);

            //new DriverManager().SetUpDriver(new ChromeConfig());

            new DriverManager().SetUpDriver(
                "https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/120.0.6099.109/win64/chromedriver-win64.zip",
                Path.Combine(Directory.GetCurrentDirectory(), "chromedriver.exe"),
                "chromedriver.exe"
            );

            //return new ChromeDriver("F:\\Data\\Work\\Projects\\C#\\AssessmentDeliveryAutomation\\AssessmentDeliveryTestFramework\\Files\\CustomDrivers\\ChromiumBased\\Chrome119", options);

            return new ChromeDriver(options);
        }

        public IWebDriver CreateFirefoxDriver()
        {
            //string firefoxDriverPath = "F:\\Data\\Work\\OwnProjects\\C#\\AssessmentDeliveryAutomation\\AssessmentDeliveryTestFramework\\Core\\Driver\\CustomDrivers\\GeckoBased\\Firefox033";
            //return new FirefoxDriver(firefoxDriverPath);

            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

        public IWebDriver CreateRemoteFirefoxDriver()
        {
            //new DriverManager().SetUpDriver(new FirefoxConfig());

            var options = new FirefoxOptions();

            return new RemoteWebDriver(new Uri("http://localhost:4444"), options);
        }

        //TODO - the best example for Selenium 3 demo support!!!
        public IWebDriver CreateElectronBasedBrowserOhHai()
        {
            //var userSystemFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var options = new ChromeOptions();

            string chromeDriverPath = "F:\\Data\\Work\\OwnProjects\\C#\\AssessmentDeliveryAutomation\\AssessmentDeliveryTestFramework\\Core\\Driver\\CustomDrivers\\ChromiumBased\\Chrome89\\";

            options.BinaryLocation = "C:\\Program Files\\OhHai Browser\\OhHai Browser.exe";
            options.AddWindowType("webview");

            return new ChromeDriver(options);
        }

        public IWebDriver CreateElectronBasedBrowserMin()
        {
            //var userSystemFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var options = new ChromeOptions();

            string chromeDriverPath = "F:\\Data\\Work\\Projects\\C#\\AssessmentDeliveryAutomation_28_11_23\\AssessmentDeliveryTestFramework\\Files\\CustomDrivers\\ChromiumBased\\Chrome116\\";
            options.BinaryLocation = "c:\\Users\\User\\AppData\\Local\\min\\app-1.29.0\\min.exe";
            options.AddWindowType("webview");

            return new ChromeDriver(chromeDriverPath, options);
        }
    }
}
