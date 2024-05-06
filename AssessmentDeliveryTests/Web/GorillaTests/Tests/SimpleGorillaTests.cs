using AssessmentDeliveryTestingFramework.Core.TestManagement;
using NUnit.Framework;
using AssessmentDeliveryTestingFramework.Page;
using GorillaTests.Pages.GorillaExams;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using FluentAssertions;

namespace GorillaTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class SimpleGorillaTests : WebPageObject
    {
        private const string EXPECTED_PAGE_TITLE = "Talent Assessments for Skills-Based Hiring - TestGorilla";
        private readonly string ASSERT_MESSAGE = $"The page has a wrong title. Title should be '{EXPECTED_PAGE_TITLE}'.";

        [Test(Description = "WebTC1_Firefox")]
        [BrowserType("Firefox")]
        [Category("Web")]
        public void TestWebTC1Firefox()
        {
            var examBase = new BaseFixtures(Session.GetDriver(), Session.WebElementWaiting);
            examBase.NavigateIntoMainPage();

            Assert.That(Session.GetDriver().Title, Is.EqualTo(EXPECTED_PAGE_TITLE), ASSERT_MESSAGE);
        }

        [Test(Description = "WebTC2_Chrome")]
        [Category(BrowserType.Chrome)]
        public void TestWebTC2Chrome()
        {
            var examBase = new BaseFixtures(Session.GetDriver(), Session.WebElementWaiting);
            examBase.NavigateIntoMainPage();

            Session.GetDriver().Title.Should().Be(EXPECTED_PAGE_TITLE);
        }

        [Test(Description = "WebTC3_Default_Browser")]
        public void TestWebTC3DefaultBrowser()
        {
            var examBase = new BaseFixtures(Session.GetDriver(), Session.WebElementWaiting);
            examBase.NavigateIntoMainPage();

            Session.GetDriver().Title.Should().Be(EXPECTED_PAGE_TITLE);
        }

        [Test(Description = "WebTC3_Electron_Browser_Custom_Driver")]
        [Category(BrowserType.Min)]
        public void TestWebTC3ElectronBrowserCustomDriver()
        {
            var examBase = new BaseFixtures(Session.GetDriver(), Session.WebElementWaiting);
            Session.GetDriverFeatures<ElectronBrowserFeatures>().NavigateToUrl("https://www.testgorilla.com/");

            ClassicAssert.AreEqual(EXPECTED_PAGE_TITLE, Session.GetDriver().Title, ASSERT_MESSAGE);
        }

        [NonParallelizable]
        [Test(Description = "WebTC4_Remote_Browser_Android_Chrome")]
        [Category(BrowserType.Chrome)]
        [Category(PlatformTypes.Android)]
        public void TestWebTC4RemoteBrowserAndroidChrome()
        {
            Assert.Pass();
        }
    }
}