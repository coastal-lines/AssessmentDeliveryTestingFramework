using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using ImageMagick;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using VisualTests.Resources;

namespace VisualTests.Pages.Konva
{
    internal class KonvaDragAndDropPage : WebBasePage
    {
        private ScreenshotUtils _screenshotUtils;

        private SikuliManager _sikuliManager;

        private IWebElement OptionDnDTestLink => WebElementWaiting.WaitElement(By.PartialLinkText("Drag and Drop Stress Test"));

        private IWebElement KonvaFrame => WebElementWaiting.WaitElement(By.XPath("//div[@class='page-entry']//iframe[contains(@src, 'Beach_Game.html')]"));

        public KonvaDragAndDropPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {
            _screenshotUtils = new ScreenshotUtils(Driver);

            _sikuliManager = new SikuliManager();
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
            var snake_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeImg);
            var snake_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeFig);
            var lion_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionImg);
            var lion_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionFig);
            var giraffe_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeImg);
            var giraffe_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeFig);
            var monkey_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyImg);
            var monkey_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyFig);

            _sikuliManager.DragAndDropElementns(snake_picture, snake_figure);
            _sikuliManager.DragAndDropElementns(lion_picture, lion_figure);
            _sikuliManager.DragAndDropElementns(giraffe_picture, giraffe_figure);
            _sikuliManager.DragAndDropElementns(monkey_picture, monkey_figure);
        }

        public void MatchAllElementsByAppium()
        {
            var snake_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeImg);
            var snake_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.SnakeFig);
            var lion_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionImg);
            var lion_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.LionFig);
            var giraffe_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeImg);
            var giraffe_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.GiraffeFig);
            var monkey_picture = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyImg);
            var monkey_figure = _sikuliManager.LoadPatternFromFile(KonvaImagesData.MonkeyFig);

            _sikuliManager.DragAndDropElementns(snake_picture, snake_figure);
            _sikuliManager.DragAndDropElementns(lion_picture, lion_figure);
            _sikuliManager.DragAndDropElementns(giraffe_picture, giraffe_figure);
            _sikuliManager.DragAndDropElementns(monkey_picture, monkey_figure);
        }

        public bool IsDifferenceBetweenCanvas()
        {
            var expectedCanvasScreenshot = _screenshotUtils.LoadImageFromFile(KonvaImagesData.ExpectedResult);

            var actualCanvasScreenshot = GetCanvasScreenshot();

            return _screenshotUtils.CompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }
    }
}