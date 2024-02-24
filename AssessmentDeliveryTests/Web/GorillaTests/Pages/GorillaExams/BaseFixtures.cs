using AssessmentDeliveryTestingFramework.Core;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class BaseFixtures : WebBasePage
    {
        private const string MAIN_PAGE_URL = "https://www.testgorilla.com/";
        private const string EXAM_PAGE_URL = "https://app.testgorilla.com/preview/7aee275a-8df7-469f-98b2-68ea44c994e4?language=en";


        public BaseFixtures(IWebDriver driver, WebElementWaiting webElementWaiting) : base(driver, webElementWaiting) 
        { 
        
        }

        public void NavigateIntoMainPage()
        {
            Driver.Navigate().GoToUrl(MAIN_PAGE_URL);
        }

        public ExamBaseComponent NavigateIntoExam()
        {
            Driver.Navigate().GoToUrl(EXAM_PAGE_URL);
            return new ExamBaseComponent(Driver, WebElementWaiting);
        }
    }
}
