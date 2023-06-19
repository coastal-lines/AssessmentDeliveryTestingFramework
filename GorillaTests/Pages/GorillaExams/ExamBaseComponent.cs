using AssessmentDeliveryTestingFramework.Core;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class ExamBaseComponent : WebBasePage
    {
        private ExamNavigationComponent _examNavigationComponent;

        private ExamToolsComponent _examToolsComponent;

        private IList<IWebElement> _ListAnswersMCQ => WebElementWaiting.WaitElements(By.TagName("app-tgo-choice"));

        public ExamBaseComponent(IWebDriver driver) : base(driver) 
        { 
        
        }

        public ExamNavigationComponent ExamNavigationComponent => _examNavigationComponent ?? new ExamNavigationComponent(Driver);

        public ExamToolsComponent ExamToolsComponent => _examToolsComponent ??= new ExamToolsComponent();

        public void SelectMcqAnswer(int answerIndex = 0)
        {
            _ListAnswersMCQ[answerIndex].Click();
        }
    }
}