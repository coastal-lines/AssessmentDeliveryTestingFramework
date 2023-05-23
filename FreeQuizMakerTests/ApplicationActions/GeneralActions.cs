using FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane;
using FreeQuizMakerTests.Pages.FreeQuizMakerExams.QuestionDetailsPane;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeQuizMakerTests.ApplicationActions
{
    public class GeneralActions
    {
        private WindowsDriver _driver;

        private ToolsPage _toolsPage;

        public ToolsPage ToolsPage => _toolsPage ?? new ToolsPage(_driver);

        public GeneralActions(WindowsDriver driver)
        {
            _driver = driver;
            _toolsPage = new ToolsPage(driver);
        }

        public QuestionDetailsPage CreateNewQuestion()
        {
            ToolsPage.ClickNewQuestionButton();
            Thread.Sleep(4000);
            return new QuestionDetailsPage(_driver);
        }
    }
}