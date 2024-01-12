using AssessmentDeliveryTestingFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace AssessmentDeliveryTestingFramework.Core.Element.Web
{
    public class WebElementActions
    {
        public JavaScriptUtils JavaScriptUtils { get; } = new JavaScriptUtils();

        #region Selenium actions

        public void ClickBySelenium(IWebElement element)
        {
            element.Click();
        }

        public void RightClickBySelenium(IWebDriver driver, IWebElement element)
        {
            new Actions(driver).ContextClick(element).Build().Perform();
        }

        public void DoubleClickBySelenium(IWebDriver driver, IWebElement element)
        {
            new Actions(driver).DoubleClick(element).Build().Perform();
        }

        public void DragAndDropBySelenium(IWebDriver driver, IWebElement elementSource, IWebElement elementTarget)
        {
            new Actions(driver).DragAndDrop(elementSource, elementTarget).Build().Perform();
        }

        public void DragAndDropByCoordinatesBySelenium(IWebDriver driver, IWebElement elementSource, int x, int y)
        {
            new Actions(driver).DragAndDropToOffset(elementSource, x, y).Build().Perform();
        }

        public void ScrollBySelenium(IWebDriver driver, int x, int y)
        {
            string script = $"window.scroll({x}, {y});";

            JavaScriptUtils.ExecuteJS(driver, script);
        }

        public void MoveCursorOnElementBySelenium(IWebDriver driver, IWebElement element)
        {
            new Actions(driver).MoveToElement(element).Build().Perform();
        }

        public void SendKeysBySelenium(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public Point GetElementCoordinatesBySelenium(IWebElement element)
        {
            return element.Location;
        }

        #endregion

        #region for IFrames

        public void SwitchToTheFirstIFrame(IWebDriver driver)
        {
            driver.SwitchTo().Frame(0);
        }

        public void SwitchToIFrame(IWebDriver driver, string iframeXPath)
        {
            var iframeElement = driver.FindElement(By.XPath("//" + iframeXPath));

            driver.SwitchTo().Frame(iframeElement);
        }

        #endregion

        #region validate

        public bool IsScrollBarPresentedJS(IWebDriver driver)
        {
            var jsExecutor = driver as IJavaScriptExecutor;
            string result = Convert.ToString(jsExecutor.ExecuteScript(@"let nda = document.querySelector('.confirmation-container'); return nda.clientHeight < nda.scrollHeight;"));

            return Boolean.Parse(result);
        }

        #endregion
    }
}
