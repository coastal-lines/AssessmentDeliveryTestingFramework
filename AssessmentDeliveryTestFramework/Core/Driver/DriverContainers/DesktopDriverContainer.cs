using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium.Appium.Windows;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers
{
    public class DesktopDriverContainer : DriverContainer<WindowsDriver>
    {
        public WebElementWaiting WebElementWaiting { get; private set; }

        public DesktopWindowsElementWaiting DesktopWindowsElementWaiting { get; private set; }

        public DesktopDriverContainer(WindowsDriver driver, string name, string platform, string currentTestType) : base(driver, name, platform, currentTestType)
        {
            WebElementWaiting = new WebElementWaiting(driver);

            DesktopWindowsElementWaiting = new DesktopWindowsElementWaiting(driver);
        }
    }
}
