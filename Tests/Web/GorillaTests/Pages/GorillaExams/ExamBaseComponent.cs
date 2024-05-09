using TestingFramework.Core;
using TestingFramework.Core.Wait;
using OpenQA.Selenium;

namespace GorillaTests.Pages.GorillaExams
{
    public class ExamBaseComponent : WebBasePage
    {
        private ExamNavigationComponent _examNavigationComponent;
        private ExamToolsComponent _examToolsComponent;

        private IList<IWebElement> _ListAnswersMCQ => WebElementWaiting.WaitElements(By.TagName("app-tgo-choice"));

        public ExamBaseComponent(IWebDriver driver, WebElementWaiting webElementWaiting) : base(driver, webElementWaiting) 
        { 
        
        }

        public ExamNavigationComponent ExamNavigationComponent => _examNavigationComponent ?? new ExamNavigationComponent(Driver, WebElementWaiting);

        public ExamToolsComponent ExamToolsComponent => _examToolsComponent ??= new ExamToolsComponent();

        public void SelectMcqAnswer(int answerIndex = 0)
        {
            _ListAnswersMCQ[answerIndex].Click();
        }
    }
}