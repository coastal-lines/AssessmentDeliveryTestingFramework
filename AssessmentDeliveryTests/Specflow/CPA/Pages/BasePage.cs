using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace CPATests.Pages
{
    internal class SpecflowBasePage
    {
        public IWebDriver Driver { get; }
        public WebElementWaiting WebElementWaiting { get; }

        public SpecflowBasePage(IWebDriver driver, WebElementWaiting webElementWaiting)
        {
            Driver = driver;
            WebElementWaiting = webElementWaiting;
        }
    }
}
