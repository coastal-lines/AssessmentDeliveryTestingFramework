using AssessmentDeliveryTestingFramework.Core;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class BaseFixtures : WebBasePage
    {
        public BaseFixtures(IWebDriver driver) : base(driver) 
        { 
        
        }


        public ExamBaseComponent NavigateIntoExam()
        {
            Driver.Navigate().GoToUrl("https://app.testgorilla.com/preview/7aee275a-8df7-469f-98b2-68ea44c994e4?language=en");

            return new ExamBaseComponent(Driver);
        }
    }
}
