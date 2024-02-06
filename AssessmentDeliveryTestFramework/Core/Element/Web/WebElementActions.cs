using AssessmentDeliveryTestingFramework.Utils;
using OpenQA.Selenium;
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

        public void DoubleClickBySelenium()
        {
            new Actions(_driver).
                DoubleClick().
                Release().
                Build().
                Perform();
        }

        public void DragAndDrop(IWebDriver driver, IWebElement elementSource, IWebElement elementTarget)
        {
            new Actions(driver).DragAndDrop(elementSource, elementTarget).Build().Perform();
        }

        public void DragAndDropByCoordinates(IWebDriver driver, IWebElement elementSource, int x, int y)
        {
            new Actions(driver).DragAndDropToOffset(elementSource, x, y).Build().Perform();
        }

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

        public void SendKeysBySelenium(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        public void SendKeysBySelenium(string text)
        {
            new Actions(_driver).
                SendKeys(text).
                Release().
                Build().
                Perform();
        }

        public void PressEnterKey()
        {
            new Actions(_driver).
                SendKeys(Keys.Enter).
                Release().
                Build().
                Perform();
        }

        public void RemoveTextByActions()
        {
            new Actions(_driver).
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                Release().
                Build().
                Perform();
        }

        public void MoveToElement(IWebElement element)
        {
            new Actions(_driver).
                MoveToElement(element).
                Build().
                Perform();
        }

        public void MoveToElementByOffset(int x, int y)
        {
            new Actions(_driver).
                MoveByOffset(x, y).
                Release().
                Build().
                Perform();
        }

        public void PutTextIntoElementByOffset(int x, int y, string text)
        {
            new Actions(_driver).
                MoveByOffset(x, y).
                DoubleClick().
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                SendKeys(text).
                Release().
                Build().
                Perform();
        }

        public void PutTextIntoElementByOffset(IWebElement element, int x, int y, string text)
        {
            MoveToElement(element);

            var startPointElement = GetStartPointOfElement(element);

            MoveToElementByOffset(startPointElement.X + x, startPointElement.Y + y);

            DoubleClickBySelenium();

            RemoveTextByActions();

            SendKeysBySelenium(text);

            PressEnterKey();
        }

        public string GetText(IWebElement element)
        {
            var text = element.Text;

            if (string.IsNullOrEmpty(text))
                text = element.GetAttribute("value");

            return text ?? string.Empty;
        }

        public void WindowsPasteText()
        {
            new Actions(_driver)
                .KeyDown(Keys.Control)
                .SendKeys("v")
                .Release()
                .Build()
                .Perform();
        }

        public void WindowsCopyText()
        {
            new Actions(_driver)
                .KeyDown(Keys.Control)
                .SendKeys("a")
                .SendKeys("c")
                .KeyUp(Keys.Control)
                .Build()
                .Perform();
        }

        public void SaveDocumentByKeyboard()
        {
            new Actions(_driver)
                .KeyDown(Keys.Control)
                .SendKeys("s")
                .Build()
                .Perform();
        }

        #endregion

        #region For IFrames

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

        #region Validate

        public bool IsScrollBarPresentedJS(IWebDriver driver)
        {
            var jsExecutor = driver as IJavaScriptExecutor;
            string result = Convert.ToString(jsExecutor.ExecuteScript(@"let nda = document.querySelector('.confirmation-container'); return nda.clientHeight < nda.scrollHeight;"));

            return Boolean.Parse(result);
        }

        #endregion

        #region Utils

        public Point GetElementCoordinatesBySelenium(IWebElement element)
        {
            return element.Location;
        }

        /// <summary>
        /// Top left corner of the element
        /// </summary>
        /// <param name="element"></param>
        public Point GetStartPointOfElement(IWebElement element)
        {
            var xZero = -(element.Size.Width / 2);
            var yZero = -(element.Size.Height / 2);

            return new Point(xZero, yZero);
        }

        #endregion
    }
}
