﻿using FreeQuizMakerTests.ApplicationActions;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using FreeQuizMakerTests.Pages;
using FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane;

namespace FreeQuizMakerTests.Tests
{
    [TestFixture]
    [NonParallelizable]
    public class SimpleFreeQuizTests : DesktopPageObject
    {
        [Test]
        [Category(TestType.Desktop)]
        [Description("TC2 - FreeQuiz web page is opened from the application")]
        public void OpenQuizLinkTest()
        {
            var toolsPane = new ToolsPage(Session.GetDriver(), Session.DesktopWindowsElementWaiting, Session.WebElementWaiting);

            toolsPane.ClickMediaFreewareUrlLink();
        }

        [Test]
        [Category(TestType.Desktop)]
        [Description("TC1 - Create MCQ item")]
        public void CreateMCQItem()
        {
            var generalActions = new GeneralActions(Session.GetDriver(), Session.DesktopWindowsElementWaiting, Session.WebElementWaiting);

            var questionDetailsPage = generalActions.CreateNewQuestion();

            Assert.AreEqual("New Question", questionDetailsPage.GetQuestionEditText(), "Error");
        }
    }
}