using AptitudeTests.Pages;
using AptitudeTests.Pages.Android;
using AptitudeTests.Utils;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using NUnit.Framework.Internal;

namespace AptitudeTests.Tests
{
    public class AndroidTest : MobilePageObject
    {
        [Test]
        [Category(TestType.Android)]
        [Description("TC1")]
        public void Test1()
        {
            var androidMainScreen = new MainScreen(Session);

            var androidActions = new AndroidActions(Session.GetDriver());
            androidActions.SwipeLeft();

            var aptitudeMainScreen = androidMainScreen.OpenAptitude();

            var adsPopupObserver = new AdsPopupObserver(Session.GetDriver());
            adsPopupObserver.StartAdsMonitor();

            var test = aptitudeMainScreen.OpenTest("AGE");
        }

        [Test]
        public void SimpleTest()
        {
            Assert.Pass();
        }
    }
}