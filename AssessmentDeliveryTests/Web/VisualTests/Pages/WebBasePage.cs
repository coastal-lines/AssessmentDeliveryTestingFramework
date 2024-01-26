using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Wait;

namespace CanvasTests.Pages
{
    internal class WebBasePage
    {
        public IWebDriver Driver { get; }

        public WebElementWaiting WebElementWaiting { get; }

        public WebElementActions WebElementActions { get; }

        public WebBasePage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions)
        {
            Driver = driver;

            WebElementWaiting = webElementWaiting;

            WebElementActions = webElementActions;
        }
    }
}
