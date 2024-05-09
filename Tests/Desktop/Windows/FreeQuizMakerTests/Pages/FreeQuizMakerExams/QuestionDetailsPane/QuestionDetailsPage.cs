using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;

namespace FreeQuizMakerTests.Pages.FreeQuizMakerExams.QuestionDetailsPane
{
    public class QuestionDetailsPage : DesktopWindowsBasePage
    {
        private IWebElement QuestionEdit => WebElementWaiting.WaitElement(By.XPath("//Edit[@AutomationId='txtQuestion']"));

        public QuestionDetailsPage(WindowsDriver driver, DesktopWindowsElementWaiting desktopWindowsElementWaiting, WebElementWaiting webElementWaiting) 
            : base(driver, desktopWindowsElementWaiting, webElementWaiting)
        {

        }

        public string GetQuestionEditText()
        {
            return QuestionEdit.Text;
        }
    }
}
