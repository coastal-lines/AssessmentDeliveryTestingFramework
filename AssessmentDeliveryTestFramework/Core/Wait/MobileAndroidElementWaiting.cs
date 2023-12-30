using OpenQA.Selenium.Appium.Android;

namespace AssessmentDeliveryTestingFramework.Core.Wait
{
    public class MobileAndroidElementWaiting : ElementWaiting<AndroidDriver>
    {
        public MobileAndroidElementWaiting(AndroidDriver webDriver) : base(webDriver)
        {

        }
    }
}
