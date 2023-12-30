using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium.Appium.Android;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{
    public class MobileAndroidDriverContainer : DriverContainer<AndroidDriver>
    {
        public MobileAndroidElementWaiting MobileAndroidElementWaiting { get; private set; }

        public WebElementWaiting WebElementWaiting { get; private set; }

        public MobileAndroidDriverContainer(AndroidDriver driver, string name, string platform, string currentTestType) : base(driver, name, platform, currentTestType)
        {
            MobileAndroidElementWaiting = new MobileAndroidElementWaiting(driver);

            WebElementWaiting = new WebElementWaiting(driver);
        }
    }
}
