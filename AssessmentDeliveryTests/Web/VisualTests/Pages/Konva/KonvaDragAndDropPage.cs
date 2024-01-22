using OpenQA.Selenium;
using AssessmentDeliveryTestingFramework.Core.Wait;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using ImageMagick;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;

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
            _screenshotUtils = new ScreenshotUtils();

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

            return _screenshotUtils.TakeScreenshotAndCutRoi(Driver, x, y, w, h);
        }

        public void MatchAllElements()
        {
            var session = _sikuliManager.CreateSikuliSession();

            var snake_picture = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\snake.jpg");
            var snake_figure = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\snake2.jpg");
            var lion_picture = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\lion.jpg");
            var lion_figure = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\lion2.jpg");
            var giraffe_picture = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\giraffe.jpg");
            var giraffe_figure = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\giraffe2.jpg");
            var monkey_picture = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\monkey.jpg");
            var monkey_figure = _sikuliManager.LoadPatternFromFile(ImagePatternsPath + "\\monkey2.jpg");

            _sikuliManager.DragAndDropElementns(session, snake_picture, snake_figure);
            _sikuliManager.DragAndDropElementns(session, lion_picture, lion_figure);
            _sikuliManager.DragAndDropElementns(session, giraffe_picture, giraffe_figure);
            _sikuliManager.DragAndDropElementns(session, monkey_picture, monkey_figure);

            session.Dispose();
        }

        //TODO - move actual and expected images into test's method
        public bool CompareTwoScreenshots()
        {
            var expectedCanvasScreenshot = _screenshotUtils.LoadImageFromFile(ImagePatternsPath + "\\expected_result.jpg");

            var actualCanvasScreenshot = GetCanvasScreenshot();

            return _screenshotUtils.CompareTwoScreenshots(actualCanvasScreenshot, expectedCanvasScreenshot);
        }
    }
}