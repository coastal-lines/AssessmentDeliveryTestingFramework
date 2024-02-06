using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.PageObjects.Desktop.Windows
{
    public class SystemMenuPage
    {
        private DesktopSession _desktopSession;
        private IWebElement elementSystemMenuSizeItem => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Menu[@Name='System']//MenuItem[@Name='Size']"));
        private IWebElement elementSystemMenuCloseItem => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Menu[@Name='System']//MenuItem[@Name='Close']"));

        public SystemMenuPage(DesktopSession desktopSession)
        {
            _desktopSession = desktopSession;
        }

        public void ClickClose()
        {
            elementSystemMenuCloseItem.Click();
        }

        public void ClickSize()
        {
            elementSystemMenuSizeItem.Click();
        }
    }
}
