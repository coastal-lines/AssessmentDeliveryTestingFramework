using TestingFramework.Core.Element.Web;
using TestingFramework.Core.Wait;
using TestingFramework.Utils.VisionUtils;
using CanvasTests.Resources;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CanvasTests.Pages.Konva
{
    internal class KonvaEditableTextPage : WebBasePage
    {
        private IWebElement ComplexDemoTextElement => WebElementWaiting.WaitElement(By.XPath("//p[contains(text(), 'Complex demo:')]"));

        private IWebElement EditableTextFrame => WebElementWaiting.WaitElement(By.CssSelector(".page-entry > iframe:nth-of-type(1)"));

        private IWebElement CanvasElement => WebElementWaiting.WaitElement(By.TagName("canvas"));

        public KonvaEditableTextPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {

        }

        public void ScrollToComplexDemoTextElement()
        {
            WebElementActions.MoveToElement(ComplexDemoTextElement);
        }

        public void PutTextIntoCanvasElement(int x, int y, string text)
        {
            Driver.SwitchTo().Frame(EditableTextFrame);

            WebElementActions.PutTextIntoElementByOffset(CanvasElement, x, y, text);

            Driver.SwitchTo().DefaultContent();
        }

        public string GetTextFromCanvasElement()
        {
            Driver.SwitchTo().Frame(EditableTextFrame);

            return WebElementActions.JavaScriptUtils.ExecuteJS(Driver, "return window.layer.children[0].text()");
        }

        public bool IsDifferenceBetweenCanvases()
        {
            var expectedCanvasScreenshot = ScreenshotUtils.LoadImageFromFile(KonvaEditableTextImagesData.ExpectedResult);

            var actualCanvasScreenshot = ScreenshotUtils.TakeElementScreenshot(EditableTextFrame);

            return ScreenshotUtils.MagickImageCompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }
    }
}
