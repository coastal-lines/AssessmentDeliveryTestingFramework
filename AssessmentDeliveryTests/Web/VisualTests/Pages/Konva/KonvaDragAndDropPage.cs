using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using ImageMagick;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using CanvasTests.Resources;
using OpenQA.Selenium.Appium.Windows;
using AssessmentDeliveryTestingFramework.Utils.FileUtils;
using AssessmentDeliveryTestingFramework.Utils;

namespace CanvasTests.Pages.Konva
{
    internal class KonvaDragAndDropPage : WebBasePage
    {
        private IWebElement OptionDnDTestLink => WebElementWaiting.WaitElement(By.PartialLinkText("Drag and Drop Stress Test"));

        private IWebElement KonvaFrame => WebElementWaiting.WaitElement(By.XPath("//div[@class='page-entry']//iframe[contains(@src, 'Beach_Game.html')]"));

        private IWebElement CanvasElement => WebElementWaiting.WaitElement(By.ClassName("konvajs-content"));

        public KonvaDragAndDropPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {

        }

        public IWebElement GetCanvasElement()
        {
            return WebElementWaiting.WaitElement(By.ClassName("konvajs-content"));
        }

        public string ImagePatternsPath { get; private set; } = Directory.GetCurrentDirectory() + ConfigurationManager.GetConfigurationModel().Resources.VisualTests.KonvaDragAndDropPatternImagesPath;

        public void ScrollToCanvasElement()
        {
            WebElementActions.MoveToElement(OptionDnDTestLink);
        }

        public MagickImage GetCanvasScreenshot()
        {
            var v_difference = WebElementActions.JavaScriptUtils.GetVerticalDifferenceBetweenTopAndCurrentPagePosition(Driver);

            var x = KonvaFrame.Location.X;
            var y = KonvaFrame.Location.Y - v_difference;
            var w = KonvaFrame.Size.Width;
            var h = KonvaFrame.Size.Height;

            return ScreenshotUtils.TakeScreenshotAndCutRoi(x, y, w, h);
        }

        public void MatchAllElementsBySikuli()
        {
            var snakePicture = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.SnakeImg);
            var snakeFigure = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.SnakeFig);
            var lionPicture = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.LionImg);
            var lionFigure = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.LionFig);
            var giraffePicture = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.GiraffeImg);
            var giraffeFigure = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.GiraffeFig);
            var monkeyPicture = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.MonkeyImg);
            var monkeyFigure = SikuliManager.LoadPatternFromFile(KonvaDragAndDropImagesData.MonkeyFig);

            SikuliManager.DragAndDropElementns(snakePicture, snakeFigure);
            SikuliManager.DragAndDropElementns(lionPicture, lionFigure);
            SikuliManager.DragAndDropElementns(giraffePicture, giraffeFigure);
            SikuliManager.DragAndDropElementns(monkeyPicture, monkeyFigure);
        }

        public void MatchAllElementsByAppium(WindowsDriver windowsDriver)
        {
            var snakePictureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.SnakeImg);
            var snakeFigureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.SnakeFig);
            var lionPictureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.LionImg);
            var lionFigureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.LionFig);
            var giraffePictureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.GiraffeImg);
            var giraffeFigureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.GiraffeFig);
            var monkeyPictureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.MonkeyImg);
            var monkeyFigureElement = AppiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaDragAndDropImagesData.MonkeyFig);

            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, snakePictureElement, snakeFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, lionPictureElement, lionFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, giraffePictureElement, giraffeFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, monkeyPictureElement, monkeyFigureElement);
        }

        public bool IsDifferenceBetweenCanvases()
        {
            var expectedCanvasScreenshot = ScreenshotUtils.LoadImageFromFile(KonvaDragAndDropImagesData.ExpectedResult);

            var actualCanvasScreenshot = GetCanvasScreenshot();

            return ScreenshotUtils.MagickImageCompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }

        public bool IsDifferenceBetweenScreenshots(WindowsDriver windowsDriver)
        {
            var actualScreenshot = ScreenshotUtils.TakeScreenshotAsBase64();

            var imageFile = LoadFilesUtils.ReadFileAsByteArray(KonvaDragAndDropImagesData.ExpectedResultFullScreenshot);
            var expectedScreenshot = Base64Utils.ConvertByteArrayToBase64(imageFile);

            return ScreenshotUtils.AppiumCompareTwoScreenshots(windowsDriver, actualScreenshot, expectedScreenshot);
        }
    }
}