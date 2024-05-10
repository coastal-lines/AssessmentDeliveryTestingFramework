using TestingFramework.Core.Session;
using NUnit.Framework;

namespace CanvasTests.Pages
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
            Session.GetDriver().Quit();

            Session.TearDown();
        }
    }
}
