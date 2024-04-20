using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Page;
using NUnit.Framework;

namespace GorillaTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class MinBrowserTests : WebPageObject
    {
        [Test(Description = "TC4")]
        [Category(BrowserType.Min)]
        public void MinBrowserTest()
        {
            Session.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.CurrentThread.Join(5000);
            Console.WriteLine("Test executed on thread " + Thread.CurrentThread.ManagedThreadId);
            Session.GetDriverFeatures<ElectronBrowserFeatures>().NavigateToUrl("https://www.testgorilla.com/");

            Assert.AreEqual("Talent Assessments for Skills-Based Hiring - TestGorilla", Session.GetDriver().Title, $"The {"https://www.testgorilla.com/"} page has a wrong title.");
        }
    }
}
