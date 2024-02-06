using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.PageObjects.Desktop.Windows
{
    public class NotepadPage
    {
        private DesktopSession _desktopSession;
        private IWebElement _elementCloseDocumentButton => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//TitleBar[@AutomationId='TitleBar']/Button[@Name='Close']"));
        private IWebElement _elementMaximizeDocumentButton => _desktopSession.WebElementWaiting.WaitElement(By.Name("Maximize"));
        private IWebElement _elementTextArea => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//Document[@Name='Text Editor']"));
        private IWebElement _elementFileOfMenuBar => _desktopSession.WebElementWaiting.WaitElement(By.Name("File"));
        private IWebElement _elementSaveOfMenuBar => _desktopSession.WebElementWaiting.WaitElement(By.Name("Save"));
        private IWebElement _elementSaveDialogDontSaveButton => _desktopSession.WebElementWaiting.WaitElement(By.Name("Don't Save"));

        public NotepadPage(DesktopSession desktopSession)
        {
            _desktopSession = desktopSession;
        }

        public void PrintTextIntoNotepad(string text)
        {
            _desktopSession.WebElementActions.SendKeysBySelenium(_elementTextArea, text);
        }

        public void PasteTextFromClipboard()
        {
            _elementTextArea.Click();
            _desktopSession.WebElementActions.WindowsPasteText();
        }

        public void CopyTextIntoClipboard()
        {
            _desktopSession.WebElementActions.WindowsCopyText();
        }

        public string GetTextFromNotepad()
        {
            return _desktopSession.WebElementActions.GetText(_elementTextArea);
        }

        public void SaveFileByMenuBar()
        {
            _elementFileOfMenuBar.Click();
            _elementSaveOfMenuBar.Click();
        }

        public void CloseNotepadByTitleBar()
        {
            _elementCloseDocumentButton.Click();
        }

        public void CloseDontSave()
        {
            _elementCloseDocumentButton.Click();
            _elementSaveDialogDontSaveButton.Click();
        }

        public void MaximizeNotepad()
        {
            _elementMaximizeDocumentButton.Click();
        }
    }
}
