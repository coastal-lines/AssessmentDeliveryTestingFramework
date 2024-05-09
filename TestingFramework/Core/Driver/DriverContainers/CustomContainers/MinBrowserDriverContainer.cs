using TestingFramework.Core.Browsers.Min;
using OpenQA.Selenium;

namespace TestingFramework.Core.Driver.DriverContainers.CustomContainers
{
    public class MinBrowserDriverContainer : BrowserDriverContainer
    {
        public ElectronBrowserFeatures BrowserFeatures { get; }

        public MinBrowserDriverContainer(ElectronBrowserFeatures electronBrowserFeatures, IWebDriver driver, string name, string platform, string browserType, string currentTestType) : base(driver, name, platform, browserType, currentTestType)
        {
            BrowserFeatures = electronBrowserFeatures;
        }
    }
}
