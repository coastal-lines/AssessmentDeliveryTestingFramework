using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver
{
    public class MinBrowserDriverContainer : BrowserDriverContainer
    {
        public ElectronBrowserFeatures BrowserFeatures { get; }

        public MinBrowserDriverContainer(ElectronBrowserFeatures electronBrowserFeatures, IWebDriver driver, string name, string platform, string browserType) : base(driver, name, platform, browserType)
        {
            BrowserFeatures = electronBrowserFeatures;
        }
    }

    public class BrowserDriverContainer : DriverContainer<IWebDriver>
    {
        private string _browserType;

        public string BrowserType => _browserType;

        public WebElementWaiting WebElementWaiting { get; private set; }

        public BrowserDriverContainer(IWebDriver driver, string name, string platform, string browserType) : base(driver, name, platform)
        {
            WebElementWaiting = new WebElementWaiting(driver);

            _browserType = browserType;
        }
    }

    public class DesktopDriverContainer : DriverContainer<WindowsDriver>
    {
        public string CurrentTestType { get; private set; }

        //Appium 4.4.5
        /*
        public DesktopDriverContainer(WindowsDriver<IWebElement> driver, string name, string platform, string currentTestType) : base(driver, name, platform)
        {
            CurrentTestType = currentTestType;
        }
        */

        //Appium 2.x
        public DesktopDriverContainer(WindowsDriver driver, string name, string platform, string currentTestType) : base(driver, name, platform)
        {
            CurrentTestType = currentTestType;
        }
    }

    public class MobileAndroidDriverContainer : DriverContainer<AndroidDriver>
    {
        public string CurrentTestType { get; private set; }

        public MobileAndroidElementWaiting MobileAndroidElementWaiting { get; private set; }

        public WebElementWaiting WebElementWaiting { get; private set; }

        public MobileAndroidDriverContainer(AndroidDriver driver, string name, string platform, string currentTestType) : base(driver, name, platform)
        {
            MobileAndroidElementWaiting = new MobileAndroidElementWaiting(driver);

            WebElementWaiting = new WebElementWaiting(driver);

            CurrentTestType = currentTestType;
        }
    }

    public interface IDriverContainer
    {
        object Driver { get; }
        string Name { get; }
        string Platform { get; }
    }

    public class DriverContainer<TDriver> : IDriverContainer where TDriver : IWebDriver
    {
        private object _driver;
        private string _name;
        private string _platform;

        public DriverContainer(TDriver driver, string name, string platform)
        {
            _driver = driver;
            _name = name;
            _platform = platform;
        }

        public object Driver => _driver;

        public string Name => _name;

        public string Platform => _platform;
    }
}