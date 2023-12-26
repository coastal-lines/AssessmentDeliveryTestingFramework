using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using NUnit.Framework;
using OpenQA.Selenium;

namespace FreeQuizMakerTests.Pages
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class DesktopPageObject
    {
        private DesktopSession _session;

        public DesktopSession Session => _session;

        [SetUp]
        public void Setup()
        {
            _session = new DesktopSession();
        }

        [TearDown]
        public void TearDown()
        {
            Session.TearDown("FreeQuizMaker");
        }
    }
}
