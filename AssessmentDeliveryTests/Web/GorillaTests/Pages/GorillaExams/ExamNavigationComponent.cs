using AssessmentDeliveryTestingFramework;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class ExamNavigationComponent : WebBasePage
    {
        private IWebElement _ImageLogo => WebElementWaiting.WaitElement(By.XPath("//content//img[@src='assets/tgo-logo.jpeg']"));

        public ExamNavigationComponent(IWebDriver driver, WebElementWaiting webElementWaiting) : base(driver, webElementWaiting)
        {
            
        }

        public bool IsLogoImageDisplayed()
        {
            return _ImageLogo.Displayed;
        }
    }
}
