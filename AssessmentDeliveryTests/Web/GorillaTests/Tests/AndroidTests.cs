using AssessmentDeliveryTestingFramework.Core.Browsers.Min;
using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorillaTests.Tests
{
    [TestFixture]
    public class AndroidTests : WebPageObject
    {
        [Test(Description = "TC5")]
        [Category(BrowserType.Chrome)]
        [Category(PlatformTypes.Android)]
        public void Test4()
        {
            Session.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Thread.CurrentThread.Join(5000);
            Console.WriteLine("Test executed on thread " + Thread.CurrentThread.ManagedThreadId);
            Session.GetDriverFeatures<ElectronBrowserFeatures>().NavigateToUrl("https://www.testgorilla.com/");

            Assert.AreEqual("Talent Assessments for Skills-Based Hiring - TestGorilla", Session.GetDriver().Title, $"The {"https://www.testgorilla.com/"} page has a wrong title.");
        }
    }
}
