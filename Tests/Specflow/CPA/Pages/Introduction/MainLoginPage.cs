using AssessmentDeliveryTestingFramework.Core.Wait;
using CPATests.Utils;
using OpenQA.Selenium;

namespace CPATests.Pages.Introduction
{
    internal class MainLoginPage : SpecflowBasePage
    {
        private IWebElement _LaunchCode => WebElementWaiting.WaitElement(By.CssSelector(".esid-container h4"));

        private IWebElement _ContinueButton => WebElementWaiting.WaitElement(By.CssSelector(".action-area button"));

        public MainLoginPage(IWebDriver driver, WebElementWaiting webElementWaiting) : base(driver, webElementWaiting)
        {

        }

        public string GetLaunchCode()
        {
            var codeText = _LaunchCode.Text;

            var launchCode = GeneralUtils.RegExpUtils.Matching("(Your Launch Code: )(.*)", codeText, 1);

            return launchCode;
        }

        public void ClickContinue()
        {
            _ContinueButton.Click();
        }
    }
}
