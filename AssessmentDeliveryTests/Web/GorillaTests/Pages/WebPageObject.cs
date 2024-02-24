using AssessmentDeliveryTestingFramework.Core.Session;
using NUnit.Framework;

/*
[SetUpFixture]
public static class MySetUpClass
{
    [OneTimeSetUp]
    public static void RunBeforeAnyTests()
    {
        Directory.SetCurrentDirectory("AssessmentDeliveryTests\\Web\\GorillaTests\\bin\\Debug\\net6.0\\");
    }
}
*/

namespace AssessmentDeliveryTestingFramework.Page
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