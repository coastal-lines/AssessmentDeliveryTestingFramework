using TestingFramework.Core.Session;
using OpenQA.Selenium;

namespace TestingFramework.PageObjects.Desktop.Windows.MSOffice
{
    public class WordApplicationPage
    {
        private DesktopSession _desktopSession;

        private IWebElement ElementDocumentPane => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//*[@AutomationId='Body']/../.."));

        public WordApplicationPage(DesktopSession desktopSession) 
        {
            _desktopSession = desktopSession;
        }

        public void PutTextIntoDocumentAfterClearing(string text)
        {
            _desktopSession.WebElementActions.SendKeysBySelenium(ElementDocumentPane, text);
        }
    }
}
