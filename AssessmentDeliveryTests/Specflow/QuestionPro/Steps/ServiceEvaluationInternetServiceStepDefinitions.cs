using AssessmentDeliveryTestingFramework.Core.Session;
using NUnit.Framework;
using OpenQA.Selenium;
using QuestionProTests.Pages;
using System;
using TechTalk.SpecFlow;

namespace QuestionProTests.Steps
{
    [Binding]
    public class ServiceEvaluationInternetServiceStepDefinitions
    {
        private WebSession _session;

        private BindingScenarioContext _scenarioContext;

        private ServiceEvaluationInternetServicePage _serviceEvaluationInternetServicePage;

        public ServiceEvaluationInternetServiceStepDefinitions(WebSession session, BindingScenarioContext scenarioContext) 
        {
            _session = session;

            _scenarioContext = scenarioContext;

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

            //ScenarioContext.Current["QuestionContainerElement"] = questionContainerElement;
            _scenarioContext["QuestionContainerElement"] = questionContainerElement;

            _session.WebElementActions.ScrollToElement(questionTitleElement);
        }

        [Then(@"User provides answers")]
        public void ThenUserProvidesAnswers(Table table)
        {
            IWebElement questionContainerElement = (IWebElement)_scenarioContext["QuestionContainerElement"];
        }
    }
}