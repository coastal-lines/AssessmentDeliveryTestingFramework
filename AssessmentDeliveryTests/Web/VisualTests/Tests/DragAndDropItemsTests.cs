using AngleSharp.Dom;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using AssessmentDeliveryTestingFramework.Utils;
using AssessmentDeliveryTestingFramework.Utils.VisionUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        }
    }
}