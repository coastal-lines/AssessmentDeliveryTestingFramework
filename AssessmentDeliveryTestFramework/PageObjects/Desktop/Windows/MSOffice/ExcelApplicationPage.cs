using AssessmentDeliveryTestingFramework.Core.Session;
using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.PageObjects.Desktop.Windows.MSOffice
{
    public class ExcelApplicationPage
    {
        private DesktopSession _desktopSession;

        private IWebElement ElementExcelGrid => _desktopSession.WebElementWaiting.WaitElement(By.XPath("//TabItem[@Name='Sheet Sheet1']/DataGrid[@AutomationId='Grid']"));

        public ExcelApplicationPage(DesktopSession desktopSession)
        {
            _desktopSession = desktopSession;
        }

        public IWebElement NavigateToCustomCell(string column, int row)
        {
            var customCell = ElementExcelGrid.FindElement(By.XPath($"//DataItem[@Name='{column.ToUpper() + row.ToString()}']"));
            customCell.Click();

            return customCell;
        }

        public void PrintTextIntoCustomCell(string column, int row, string text)
        {
            var customCell = NavigateToCustomCell(column, row);
            _desktopSession.WebElementActions.SendKeysBySelenium(customCell, text);
        }
    }
}
