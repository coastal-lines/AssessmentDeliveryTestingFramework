using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{
    public class BrowserDriverContainer : DriverContainer<IWebDriver>
    {
        private string _browserType;

        public string BrowserType => _browserType;

        public WebElementWaiting WebElementWaiting { get; private set; }

        public BrowserDriverContainer(IWebDriver driver, string name, string platform, string browserType, string currentTestType) : base(driver, name, platform, currentTestType)
        {
            WebElementWaiting = new WebElementWaiting(driver);

            _browserType = browserType;
        }
    }
}