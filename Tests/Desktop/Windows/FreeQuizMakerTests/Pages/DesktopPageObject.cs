using TestingFramework.Core.Session;
using TestingFramework.Core.TestManagement;
using TestingFramework.Core.Utils.Config;
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
            var applicationPath = ConfigurationManager.GetConfigurationModel().Desktop.ApplicationPath;

            _session = new DesktopSession(applicationPath);
        }

        [TearDown]
        public void TearDown()
        {
            _session.GetDriver().Quit();

            Session.TearDown("FreeQuizMaker");
        }
    }
}
