using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;
using QuestionProTests.Hooks;
using QuestionProTests.Pages;
using TechTalk.SpecFlow;

namespace QuestionProTests.Steps
{
    [Binding]
    internal class ServiceEvaluationInternetServiceStepDefinitions
    {
        private WebSession _session;

        private ScenarioContextManager _contextManager;

        private ServiceEvaluationInternetServicePage _serviceEvaluationInternetServicePage;

        public ServiceEvaluationInternetServiceStepDefinitions(WebSession session, ScenarioContextManager contextManager)
        {
            _session = session;

            _contextManager = contextManager;

            _serviceEvaluationInternetServicePage = new ServiceEvaluationInternetServicePage(session);
        }

        [Given(@"User navigates to Service Evaluation template")]
        public void GivenUserNavigatesToServiceEvaluationTemplate()
        {
            _session.GetDriver().Navigate().GoToUrl("https://www.questionpro.com/survey-templates/service-evaluation-internet-service-provider/");
        }

        [When(@"User scrolls to question '([^']*)'")]
        public void WhenUserScrollsToQuestion(string questionText)
        {
            IWebElement questionContainerElement;
            IWebElement questionTitleElement;
            _serviceEvaluationInternetServicePage.GetElementByQuestion(questionText, out questionContainerElement, out questionTitleElement);

            _contextManager.SetContextValue("QuestionContainerElement", questionContainerElement);

            _session.WebElementActions.ScrollToElement(questionTitleElement);
        }

        [Then(@"User provides answers")]
        public void ThenUserProvidesAnswers(Table table)
        {
            var questionContainerElement = _contextManager.GetContextValue<IWebElement>("QuestionContainerElement");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                int answerColumnIndex = Int16.Parse(GetValueFromTable(table, i, 1));

                _serviceEvaluationInternetServicePage.ProvideAnswerForTable(questionContainerElement, answerColumnIndex, i + 1);
            }
        }

        public string GetValueFromTable(Table table, int row, int column)
        {
            return table.Rows[row].Values.ToList()[column];
        }
    }
}