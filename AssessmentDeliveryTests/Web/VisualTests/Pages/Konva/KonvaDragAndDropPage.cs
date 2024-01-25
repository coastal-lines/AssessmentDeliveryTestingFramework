using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using ImageMagick;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using VisualTests.Resources;
using OpenQA.Selenium.Appium.Windows;

namespace VisualTests.Pages.Konva
{
    internal class KonvaDragAndDropPage : WebBasePage
    {
        private ScreenshotUtils _screenshotUtils;

        private SikuliManager _sikuliManager;

        private AppiumImagePluginUtils _appiumImagePluginUtils;

        private IWebElement OptionDnDTestLink => WebElementWaiting.WaitElement(By.PartialLinkText("Drag and Drop Stress Test"));

        private IWebElement KonvaFrame => WebElementWaiting.WaitElement(By.XPath("//div[@class='page-entry']//iframe[contains(@src, 'Beach_Game.html')]"));

        private IWebElement CanvasElement => WebElementWaiting.WaitElement(By.ClassName("konvajs-content"));

        public KonvaDragAndDropPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {
            _screenshotUtils = new ScreenshotUtils(Driver);

            _sikuliManager = new SikuliManager();

            _appiumImagePluginUtils = new AppiumImagePluginUtils();
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

            return _screenshotUtils.TakeScreenshotAndCutRoi(x, y, w, h);
        }

        public void MatchAllElementsBySikuli()
        {
            var snakePicture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeImg);
            var snakeFigure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeFig);
            var lionPicture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionImg);
            var lionFigure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionFig);
            var giraffePicture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeImg);
            var giraffeFigure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeFig);
            var monkeyPicture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyImg);
            var monkeyFigure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyFig);

            _sikuliManager.DragAndDropElementns(snakePicture, snakeFigure);
            _sikuliManager.DragAndDropElementns(lionPicture, lionFigure);
            _sikuliManager.DragAndDropElementns(giraffePicture, giraffeFigure);
            _sikuliManager.DragAndDropElementns(monkeyPicture, monkeyFigure);
        }

        public void MatchAllElementsByAppium(WindowsDriver windowsDriver)
        {
            var snakePictureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.SnakeImg);
            var snakeFigureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.SnakeFig);
            var lionPictureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.LionImg);
            var lionFigureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.LionFig);
            var giraffePictureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.GiraffeImg);
            var giraffeFigureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.GiraffeFig);
            var monkeyPictureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.MonkeyImg);
            var monkeyFigureElement = _appiumImagePluginUtils.FindElementByImagePattern(windowsDriver, KonvaImagesData.MonkeyFig);

            //Calculate vertical shift. Difference betveen frame position and current page position.
            var v_difference = WebElementActions.JavaScriptUtils.GetVerticalDifferenceBetweenTopAndCurrentPagePosition(Driver);

            _appiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, snakePictureElement, snakeFigureElement, v_difference);
            _appiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, lionPictureElement, lionFigureElement, v_difference);
            _appiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, giraffePictureElement, giraffeFigureElement, v_difference);
            _appiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, monkeyPictureElement, monkeyFigureElement, v_difference);
        }

        public bool IsDifferenceBetweenCanvas()
        {
            var expectedCanvasScreenshot = _screenshotUtils.LoadImageFromFile(KonvaImagesData.ExpectedResult);

            var actualCanvasScreenshot = GetCanvasScreenshot();

            return _screenshotUtils.CompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }
    }
}