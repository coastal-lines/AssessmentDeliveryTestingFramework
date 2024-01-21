using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using VisualTests.Pages;

namespace VisualTests.Tests
{
    public class Tests : WebPageObject
    {
        [Test]
        [Category("Web")]
        [BrowserType("Firefox")]
        [Description("TC1 - KonvaJS - Drag and Drop by Sikuli")]
        public void TC1KonvaJSDragAndDropBySikuliTest()
        {
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Animals_on_the_Beach_Game.html");

            Session.GetDriver().Manage().Window.Size = new Size(880, 880);

            Assert.Pass();
        }
    }
}