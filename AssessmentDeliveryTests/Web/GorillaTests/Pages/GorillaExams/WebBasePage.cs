using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class WebBasePage
    {
        public IWebDriver Driver { get; }
        public WebElementWaiting WebElementWaiting { get; }

        public WebBasePage(IWebDriver driver, WebElementWaiting webElementWaiting)
        {
            Driver = driver;
            WebElementWaiting = webElementWaiting;
        }

        /*
        private IWebDriver _driver;

        private WebElementWaiting _elementWait;

        public IWebDriver Driver => _driver;

        public WebElementWaiting WebElementWaiting => _elementWait;

        public WebBasePage(IWebDriver driver, WebElementWaiting webElementWaiting)
        {
            _driver = driver;

            _elementWait = webElementWaiting;
        }
        */
    }
}
