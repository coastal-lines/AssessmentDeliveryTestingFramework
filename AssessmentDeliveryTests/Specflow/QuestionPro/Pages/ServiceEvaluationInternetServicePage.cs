using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;

namespace QuestionProTests.Pages
{
    internal class ServiceEvaluationInternetServicePage
    {
        private readonly WebSession _session;

        private IList<IWebElement> _QuestionElementList => _session.WebElementWaiting.WaitElements(By.XPath("//div[@id='desktop']//div[contains(@id, 'QuestionSection')]"));

        public ServiceEvaluationInternetServicePage(WebSession session) 
        {
            _session = session;
        }

        public void GetElementByQuestion(string questionText, out IWebElement questionContainerElement, out IWebElement questionTitleElement)
        {
            foreach (var el in _QuestionElementList)
            {
                var tempQuestionTitleElement = el.FindElement(By.ClassName("question-text-span"));

                var t1 = tempQuestionTitleElement.Text;
                Console.WriteLine(t1);

                if (tempQuestionTitleElement.Text.Contains(questionText))
                {
                    Console.WriteLine(questionText);

                    questionContainerElement = el;

                    questionTitleElement = tempQuestionTitleElement;

                    return;
                }
            }

            throw new NoSuchElementException($"Element with question '{questionText}' was not found.");
        }
    }
}
