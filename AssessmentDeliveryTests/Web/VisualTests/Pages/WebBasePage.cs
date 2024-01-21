using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace VisualTests.Pages
{
    internal class WebBasePage
    {
        public IWebDriver Driver { get; }

        public WebElementWaiting WebElementWaiting { get; }

        public WebBasePage(IWebDriver driver, WebElementWaiting webElementWaiting)
        {
            Driver = driver;
            WebElementWaiting = webElementWaiting;
        }
    }
}
