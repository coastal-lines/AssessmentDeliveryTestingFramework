using OpenQA.Selenium;
using TestingFramework.Core.Wait;
using TestingFramework.Core.Element.Web;
using TestingFramework.Utils.VisionUtils;
using ImageMagick;
using TestingFramework.Core.Utils.Config;
using CanvasTests.Resources;
using OpenQA.Selenium.Appium.Windows;
using TestingFramework.Utils.FileUtils;
using TestingFramework.Utils;
using TestingFramework.Core.Driver.DriverContainers;

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

        public void MatchAllElementsByAppium(DesktopDriverContainer desktopDriverContainer)
        {
            var snakePictureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.SnakeImg);
            var snakeFigureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.SnakeFig);
            var lionPictureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.LionImg);
            var lionFigureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.LionFig);
            var giraffePictureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.GiraffeImg);
            var giraffeFigureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.GiraffeFig);
            var monkeyPictureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.MonkeyImg);
            var monkeyFigureElement = desktopDriverContainer.DesktopWindowsElementWaiting.FindElementByImagePattern(KonvaDragAndDropImagesData.MonkeyFig);

            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, snakePictureElement, snakeFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, lionPictureElement, lionFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, giraffePictureElement, giraffeFigureElement);
            AppiumImagePluginUtils.DragAndDropByCoordinatesInFrame(Driver, KonvaFrame, GetCanvasElement, WebElementActions, monkeyPictureElement, monkeyFigureElement);
        }

        public bool IsDifferenceBetweenCanvases()
        {
            var expectedCanvasScreenshot = ScreenshotUtils.LoadImageFromFile(KonvaDragAndDropImagesData.ExpectedResult);

            var actualCanvasScreenshot = ScreenshotUtils.TakeElementScreenshot(KonvaFrame);

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