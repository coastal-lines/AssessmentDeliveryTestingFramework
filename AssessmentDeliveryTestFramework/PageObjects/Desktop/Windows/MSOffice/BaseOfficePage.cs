using AssessmentDeliveryTestingFramework.Core.Logging;
using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.PageObjects.Desktop.Windows.MSOffice
{
    public class BaseOfficePage
    {
        private DesktopSession _desktopSession;

        #region Quick accsess bar

        private IWebElement ElementSaveButtonOfQuickAccessPanel => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//ToolBar[@Name='Quick Access Toolbar']/Button[@Name='Save']"));

        #endregion

        #region Minimize maximize close application butttons

        private IWebElement ElementCloseDocumentButton => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Pane[@Name='Ribbon']//Button[@Name='Close']"));
        private IWebElement ElementMaximizeDocumentButton => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Pane[@Name='Ribbon']//Button[@Name='Maximize']"));

        #endregion

        #region Save file dialog

        private IWebElement ElementSaveChangesDialog => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@ClassName='NetUINetUIDialog']"));
        private IWebElement ElementSaveButtonOfSaveChangesDialog => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@ClassName='NetUINetUIDialog']/Button[@Name='Save']"));
        private IWebElement ElementDontSaveButtonOfSaveChangesDialog => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@ClassName='NetUINetUIDialog']/Button[@Name='Don&apos;t Save']"));
        private IWebElement ElementCancelButtonOfSaveChangesDialog => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Window[@ClassName='NetUINetUIDialog']/Button[@Name='Cancel']"));

        #endregion

        public BaseOfficePage(DesktopSession desktopSession) 
        {
            _desktopSession = desktopSession;
        }

        public void SaveDocumentByQuickAccessPanelAndCloseDocument()
        {
            ElementSaveButtonOfQuickAccessPanel.Click();
            CloseDocumentByHeaderCloseButton();
            SaveModifiedFileByDialog();
        }

        public void SaveDocumentByKeyboardCombination()
        {
            _desktopSession.WebElementActions.SaveDocumentByKeyboard();
        }

        public void SaveModifiedFileByDialog()
        {
            try
            {
                if (ElementSaveChangesDialog != null && ElementSaveChangesDialog.Displayed)
                {
                    ElementSaveButtonOfSaveChangesDialog.Click();
                }
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void CloseDocumentByHeaderCloseButton()
        {
            ElementCloseDocumentButton.Click();
        }

        public void MaximizeDocument()
        {
            try
            {
                if (ElementMaximizeDocumentButton != null)
                {
                    ElementMaximizeDocumentButton.Click();
                }
            }
            catch (WebDriverException ex)
            {
                Logger.LogError(ex.Message, ex);
                throw;
            }
        }
    }
}
