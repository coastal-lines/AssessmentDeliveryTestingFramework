using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeQuizMakerTests.Pages.FreeQuizMakerExams.QuestionDetailsPane
{
    public class QuestionDetailsPage : DesktopWindowsBasePage
    {
        private IWebElement QuestionEdit => WebElementWaiting.WaitElement(By.XPath("//Edit[@AutomationId='txtQuestion']"));

        public QuestionDetailsPage(WindowsDriver driver) : base(driver)
        {

        }

        public string GetQuestionEditText()
        {
            return QuestionEdit.Text;
        }
    }
}
