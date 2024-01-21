using AssessmentDeliveryTestingFramework.Core.Session;
using NUnit.Framework;

namespace VisualTests.Pages
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class WebPageObject
    {
        private WebSession _session;

        public WebSession Session => _session;

        [SetUp]
        public void Setup()
        {
            _session = new WebSession();
        }

        [TearDown]
        public void TearDown()
        {
            _session.GetDriver().Quit();

            Session.TearDown();
        }
    }
}
