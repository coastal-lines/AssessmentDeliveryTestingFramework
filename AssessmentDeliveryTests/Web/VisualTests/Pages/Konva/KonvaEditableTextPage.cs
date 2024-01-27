using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using CanvasTests.Resources;
using OpenQA.Selenium;

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

        /*
        public MagickImage GetCanvasScreenshot()
        {
            var v_difference = WebElementActions.JavaScriptUtils.GetVerticalDifferenceBetweenTopAndCurrentPagePosition(Driver);

            var x = EditableTextFrame.Location.X;
            var y = EditableTextFrame.Location.Y - v_difference;
            var w = EditableTextFrame.Size.Width;
            var h = EditableTextFrame.Size.Height;

            return ScreenshotUtils.TakeScreenshotAndCutRoi(x, y, w, h);
        }
        */

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

        public bool IsDifferenceBetweenCanvases()
        {
            var expectedCanvasScreenshot = ScreenshotUtils.LoadImageFromFile(KonvaEditableTextImagesData.ExpectedResult);

            var actualCanvasScreenshot = ScreenshotUtils.TakeElementScreenshot(EditableTextFrame);

            return ScreenshotUtils.MagickImageCompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }
    }
}
