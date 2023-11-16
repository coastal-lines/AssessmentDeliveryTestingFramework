using AptitudeTests.Pages;
using AptitudeTests.Pages.Android;
using AptitudeTests.Utils;
using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace AptitudeTests.Tests
{
    public class AndroidTest : MobilePageObject
    {
        [Test]
        [Category(TestType.Android)]
        //[TestCategory("Type")]
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

    /*
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class TestCategoryAttribute : NUnitAttribute, IApplyToTest
    {
        private string categoryName;

        public TestCategoryAttribute(string name)
        {
            categoryName = name.Trim();
        }

        public string Name => categoryName;

        public void ApplyToTest(Test test)
        {
            test.Properties.Add("TestCategory", Name);
        }
    }
    */

    /*
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class TestCategoryAttribute : NUnitAttribute, IApplyToTest
    {
        public TestCategoryAttribute(string name) => Name = name.Trim();

        public string Name { get; }

        public void ApplyToTest(Test test) => test.Properties.Add("TestCategory", Name);
    }
    */
}