using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using NUnit.Framework;
using System.Drawing;
using VisualTests.Pages;
using VisualTests.Pages.Konva;

namespace VisualTests.Tests
{
    public class Tests : WebPageObject
    {
        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Description("TC1 - KonvaJS - Drag and Drop by Sikuli")]
        public void TC1KonvaJSDragAndDropBySikuliTest()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Animals_on_the_Beach_Game.html");
            Session.GetDriver().Manage().Window.Size = new Size(880, 880);

            //Step 2
            var konvaDragAndDropPage = new KonvaDragAndDropPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaDragAndDropPage.ScrollToCanvasElement();

            //Step 3
            konvaDragAndDropPage.MatchAllElements();

            //Step 4
            Assert.IsTrue(konvaDragAndDropPage.IsDifferenceBetweenCanvas(), "Actual canvas has some changes.");
        }
    }
}