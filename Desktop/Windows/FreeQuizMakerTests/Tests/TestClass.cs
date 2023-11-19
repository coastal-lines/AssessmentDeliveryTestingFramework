using FreeQuizMakerTests.ApplicationActions;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using FreeQuizMakerTests.Pages;
using FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane;
using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.Driver;

namespace FreeQuizMakerTests.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class TestClass : DesktopPageObject
    {
        [Test]
        [Category(TestType.Desktop)]
        [Description("TC2 - FreeQuiz web page is opened from the application")]
        public void OpenQuizLinkTest()
        {
            var toolsPane = new ToolsPage(Session.GetDriver());
            toolsPane.ClickMediaFreewareUrlLink();
        }

        [Test]
        [Category(TestType.Desktop)]
        [Description("TC1 - Create MCQ item")]
        public void Test1()
        {

        }

        [Test]
        [Category(TestType.Desktop)]
        [Description("TC1 - Create MCQ item")]
        public void Test2()
        {
            var generalActions = new GeneralActions(Session.GetDriver());
            var questionDetailsPage = generalActions.CreateNewQuestion();
            Assert.AreEqual("New Question", questionDetailsPage.GetQuestionEditText(), "Error");
        }
    }
}