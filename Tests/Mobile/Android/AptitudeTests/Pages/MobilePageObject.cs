using TestingFramework.Core.Session;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace AptitudeTests.Pages
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class MobilePageObject
    {
        private MobileSession _session;

        public MobileSession Session => _session;

        [SetUp]
        public void Setup()
        {
            _session = new MobileSession();
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                Session.GetDriver().TerminateApp("nithra.math.aptitude");
                Session.GetWebWait().WaitElement(By.XPath($"//android.widget.TextView[@text='CLEAR ALL']")).Click();
            }
            catch (WebDriverException)
            {
                //Session.GetDriver().TerminateApp("nithra.math.aptitude");
            }

            Session.GetDriver().CloseApp();

            try
            {
                Session.GetWebWait().WaitElement(By.XPath($"//android.widget.TextView[@text='CLEAR ALL']")).Click();
                Console.WriteLine("android.widget.TextView[@text='CLEAR ALL']android.widget.TextView[@text='CLEAR ALL']android.widget.TextView[@text='CLEAR ALL']");
            }
            catch (Exception)
            {

            }

            Session.GetDriver().Quit();

            Session.PlatformDriverUtils.TerminateProcess("node");
        }
    }
}
