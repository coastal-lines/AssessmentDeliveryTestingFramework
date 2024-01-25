using AssessmentDeliveryTestingFramework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace AssessmentDeliveryTestingFramework.Core.Element.Web
{
    public class WebElementActions
    {
        private IWebDriver _driver;

        public WebElementActions(IWebDriver driver)
        {
            _driver = driver;
        }

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

        public void DragAndDrop(IWebDriver driver, IWebElement elementSource, IWebElement elementTarget)
        {
            new Actions(driver).DragAndDrop(elementSource, elementTarget).Build().Perform();
        }

        public void DragAndDropByCoordinates(IWebDriver driver, IWebElement elementSource, int x, int y)
        {
            new Actions(driver).DragAndDropToOffset(elementSource, x, y).Build().Perform();
        }

        //public void DragAndDropFromsourceToDestinationByCoordinates(IWebDriver driver, IWebElement canvasElement, int xSource, int ySource, int xDest, int yDest)
        public void DragAndDropFromsourceToDestinationByCoordinates(IWebElement canvasElement, int xSource, int ySource, int xDest, int yDest)
        {
            new Actions(_driver).MoveToElement(canvasElement, xSource, ySource).
                ClickAndHold().
                MoveToElement(canvasElement, xDest, yDest).
                Click().
                Build().
                Perform();
        }

        public void ScrollBySelenium(IWebDriver driver, int x, int y)
        {
            string script = $"window.scroll({x}, {y});";

            JavaScriptUtils.ExecuteJS(driver, script);
        }

        public void ScrollToElement(IWebElement element)
        {
            try
            {
                new Actions(_driver)
                    .ScrollToElement(element)
                    .Perform();
            }
            catch (WebDriverArgumentException)
            {
                JavaScriptUtils.ScrollToElement(_driver, element);
            }
        }

        public void MoveToElement(IWebElement element)
        {
            new Actions(_driver).MoveToElement(element).Build().Perform();
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
