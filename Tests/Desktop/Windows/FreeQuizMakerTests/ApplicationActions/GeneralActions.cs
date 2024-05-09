using AssessmentDeliveryTestingFramework.Core.Wait;
using FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane;
using FreeQuizMakerTests.Pages.FreeQuizMakerExams.QuestionDetailsPane;
using OpenQA.Selenium.Appium.Windows;

namespace FreeQuizMakerTests.ApplicationActions
{
    public class GeneralActions
    {
        private WindowsDriver _driver;

        private DesktopWindowsElementWaiting _desktopWindowsElementWaiting;

        private WebElementWaiting _webElementWaiting;

        public ToolsPage _toolsPage;

        public GeneralActions(WindowsDriver driver, DesktopWindowsElementWaiting desktopWindowsElementWaiting, WebElementWaiting webElementWaiting)
        {
            _driver = driver;

            _desktopWindowsElementWaiting = desktopWindowsElementWaiting;

            _webElementWaiting = webElementWaiting;

            _toolsPage = new ToolsPage(driver, desktopWindowsElementWaiting, webElementWaiting);
        }

        public QuestionDetailsPage CreateNewQuestion()
        {
            _toolsPage.ClickNewQuestionButton();

            return new QuestionDetailsPage(_driver, _desktopWindowsElementWaiting, _webElementWaiting);
        }
    }
}