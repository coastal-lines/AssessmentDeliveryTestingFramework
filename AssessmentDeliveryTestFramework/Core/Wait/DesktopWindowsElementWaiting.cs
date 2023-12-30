using OpenQA.Selenium.Appium.Windows;

namespace AssessmentDeliveryTestingFramework.Core.Wait
{
    public class DesktopWindowsElementWaiting : ElementWaiting<WindowsDriver>
    {
        public DesktopWindowsElementWaiting(WindowsDriver webDriver) : base(webDriver)
        {

        }
    }
}
