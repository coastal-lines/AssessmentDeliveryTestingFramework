using TestingFramework.Core.Session;
using NUnit.Framework;

namespace GorillaTests.Pages
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class WebPageObject
    {
        private WebSession _session;

        protected WebSession Session => _session;

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