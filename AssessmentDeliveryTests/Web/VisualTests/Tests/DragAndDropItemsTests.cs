using AngleSharp.Dom;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using AssessmentDeliveryTestingFramework.Utils;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SikuliSharp;
using System.Drawing;
using VisualTests.Pages;

namespace VisualTests.Tests
{
    public class Tests : WebPageObject
    {
        [Test]
        [BrowserType("Chrome")]
        [Description("TC1 - KonvaJS - Drag and Drop by Sikuli")]
        public void TC1KonvaJSDragAndDropBySikuliTest()
        {
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Animals_on_the_Beach_Game.html");

            Session.GetDriver().Manage().Window.Size = new Size(880, 880);

            Session.WebElementActions.MoveToElement(Session.GetDriver().FindElement(By.PartialLinkText("Drag and Drop Stress Test")));

            ScreenshotUtils screenshotUtils  = new ScreenshotUtils();
            screenshotUtils.TakeScreenshotAndSaveAsFile(Session.GetDriver());

            string filesFolderPath = Directory.GetCurrentDirectory() + "\\Resources\\PatternImages\\KonvaJS";
            SikuliManager sikuliManager = new SikuliManager();
            var session = sikuliManager.CreateSikuliSession();
            var snake_picture = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\snake.jpg");
            var snake_figure = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\snake2.jpg");
            var lion_picture = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\lion.jpg");
            var lion_figure = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\lion2.jpg");
            var giraffe_picture = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\giraffe.jpg");
            var giraffe_figure = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\giraffe2.jpg");
            var monkey_picture = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\monkey.jpg");
            var monkey_figure = sikuliManager.LoadPatternFromFile(filesFolderPath + "\\monkey2.jpg");
            sikuliManager.DragAndDropElementns(session, snake_picture, snake_figure);
            sikuliManager.DragAndDropElementns(session, lion_picture, lion_figure);
            sikuliManager.DragAndDropElementns(session, giraffe_picture, giraffe_figure);
            sikuliManager.DragAndDropElementns(session, monkey_picture, monkey_figure);
        }
    }
}