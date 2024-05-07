using OpenQA.Selenium.Appium.Android;

namespace TestingFramework.Core.Wait
{
    public class MobileAndroidElementWaiting : ElementWaiting<AndroidDriver>
    {
        public MobileAndroidElementWaiting(AndroidDriver webDriver) : base(webDriver)
        {

        }
    }
}
