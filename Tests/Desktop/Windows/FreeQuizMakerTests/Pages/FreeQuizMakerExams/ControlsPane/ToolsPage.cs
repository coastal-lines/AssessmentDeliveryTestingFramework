using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane
{
    public class ToolsPage : DesktopWindowsBasePage
    {
        private IWebElement MediaFreewareUrlLink => WebElementWaiting.WaitElement(By.XPath("//Text[@AutomationId='linkLabel1']"));

        private IWebElement NewQuestionButton => WebElementWaiting.WaitElement(By.XPath("//Button[@Name='New Question']"));

        private IWebElement NewQuestionButton2 => WebElementWaiting.ForceCustomWaitElements(By.XPath("//Button[@Name='New Question']"), WebElementWaiting.IsElementsSelected).FirstOrDefault();

        public ToolsPage(WindowsDriver driver, DesktopWindowsElementWaiting desktopWindowsElementWaiting, WebElementWaiting webElementWaiting) : base(driver, desktopWindowsElementWaiting, webElementWaiting)
        {

        }

        public void ClickNewQuestionButton()
        {
            NewQuestionButton.Click();
        }

        public void ClickMediaFreewareUrlLink()
        {
            MediaFreewareUrlLink.Click();
        }
    }
}
