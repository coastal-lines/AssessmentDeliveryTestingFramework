using AssessmentDeliveryTestingFramework.Core.Session;
using NUnit.Framework;
using QuestionProTests.Pages;
using System;
using TechTalk.SpecFlow;

namespace QuestionProTests.Steps
{
    [Binding]
    public class ServiceEvaluationInternetServiceStepDefinitions
    {
        private WebSession _session;

        private 

        public ServiceEvaluationInternetServiceStepDefinitions(WebSession session) 
        {
            _session = session;
        }

        [Given(@"User navigates to Service Evaluation template")]
        public void GivenUserNavigatesToServiceEvaluationTemplate()
        {
            _session.GetDriver().Navigate().GoToUrl("https://www.questionpro.com/survey-templates/service-evaluation-internet-service-provider/");
        }

        [When(@"User scrolls to table type question")]
        public void WhenUserScrollsToTableTypeQuestion()
        {
            throw new PendingStepException();
        }
    }
}