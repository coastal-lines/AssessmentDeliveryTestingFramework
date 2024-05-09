using TestingFramework.Core.Wait;
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
    }
}
