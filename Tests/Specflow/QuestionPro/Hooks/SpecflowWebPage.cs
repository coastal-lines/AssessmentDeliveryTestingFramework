using AssessmentDeliveryTestingFramework.Core.Session;
using BoDi;
using TechTalk.SpecFlow;

namespace QuestionProTests.Hooks
{
    [Binding]
    internal sealed class SpecflowWebPage
    {
        private readonly IObjectContainer container;

        public SpecflowWebPage(IObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario(Order = 1)]
        public void Setup()
        {
            var session = new WebSession();

            container.RegisterInstanceAs(session);

            //get 'ScenarioContext' object for 'ScenarioContextManager'
            var scenarioContext = container.Resolve<ScenarioContext>();

            container.RegisterInstanceAs(new ScenarioContextManager(scenarioContext));
        }

        [AfterScenario(Order = 9999)]
        public void TearDown()
        {
            var session = container.Resolve<WebSession>();

            session.GetDriver().Quit();

            session.TearDown();
        }
    }
}
