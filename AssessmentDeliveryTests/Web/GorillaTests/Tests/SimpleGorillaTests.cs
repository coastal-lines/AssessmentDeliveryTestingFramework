using AssessmentDeliveryTestingFramework.Core.TestManagement;
using NUnit.Framework;
using AssessmentDeliveryTestingFramework.Page;
using GorillaTests.Pages.GorillaExams;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;

namespace GorillaTests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class SimpleGorillaTests : WebPageObject
    {
        [Test(Description = "SimpleTest")]
        [BrowserType("Firefox")]
        [Category("Web")]
        public void SimpleTest()
        {
            Session.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Session.GetDriver().Navigate().GoToUrl("https://www.example.com");
            Console.WriteLine("Test executed on thread " + Thread.CurrentThread.ManagedThreadId);
            Thread.CurrentThread.Join(3000);
        }


        [Test(Description = "TC2")]
        [Category(BrowserType.Chrome)]
        public void Test2()
        {
            var examBase = new BaseFixtures(Session.GetDriver());
            var examBaseComponent = examBase.NavigateIntoExam();
            examBaseComponent.SelectMcqAnswer();
            //Thread.CurrentThread.Join(1000);
        }

        [Test(Description = "TC3")]
        [Category(BrowserType.Firefox)]
        public void Test3()
        {
            var examBase = new BaseFixtures(Session.GetDriver());
            var examBaseComponent = examBase.NavigateIntoExam();
            examBaseComponent.SelectMcqAnswer();
        }

        /*

        */

        /*
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
        */
    }
}

/*
            Session.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Session.GetDriver().Navigate().GoToUrl("https://www.example.com");
            Thread.CurrentThread.Join(5000);
            Console.WriteLine("Test executed on thread " + Thread.CurrentThread.ManagedThreadId);
*/