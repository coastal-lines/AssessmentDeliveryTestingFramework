using TestingFramework.Core.Session;
using TestingFramework.Utils.System;
using OpenQA.Selenium;

namespace TestingFramework.PageObjects.Desktop.Windows
{
    public class ScreensaverDialogPage
    {
        private DesktopSession _desktopSession;

        private WindowsSystemUtils _windowsSystemUtils;

        private IWebElement ElementScreenSaverDialogTitle => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@Name='Screen Saver Settings']//TitleBar[@AutomationId='TitleBar']"));     
        private IWebElement ElementComboBoxScreenSavers => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@Name='Screen Saver Settings']//ComboBox[@Name='Screen saver']"));
        private IWebElement ElementWaitTimer => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@Name='Screen Saver Settings']//Edit[@Name='Wait:']"));
        private IWebElement ElementOkButton => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@Name='Screen Saver Settings']//Button[@Name='OK']"));

        public ScreensaverDialogPage(DesktopSession desktopSession)
        {
            _desktopSession = desktopSession;

            _windowsSystemUtils = new WindowsSystemUtils();
        }

        public void OpenScreenSaverDialog()
        {
            _windowsSystemUtils.RunCmdScript("/C control desk.cpl,,@screensaver", false, false, true);
        }

        public void SwitchOnScreenSaver()
        {

        }

        public void SwitchOffScreenSaver()
        {

        }
    }
}
