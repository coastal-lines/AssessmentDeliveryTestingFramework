using CanvasTests.Pages;
using NUnit.Framework;
using System.Drawing;
using CanvasTests.Pages.Konva;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using AssessmentDeliveryTestingFramework.Core.TestManagement;

namespace CanvasTests.Tests
{
    internal class EditableTextItemsTests : WebPageObject
    {
        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        [Description("TC1 - KonvaJS - Interract by coordinates")]
        public void TС1KonvaJSInterractByCoordinates()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Editable_Text.html");
            Session.GetDriver().Manage().Window.Size = new Size(765, 900);

            //Step 2
            var konvaEditableTextPage = new KonvaEditableTextPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaEditableTextPage.ScrollToComplexDemoTextElement();

            //Step 3
            konvaEditableTextPage.PutTextIntoCanvasElement(130, 60, "Canvas test");

            //Step 4
            Assert.IsTrue(konvaEditableTextPage.IsDifferenceBetweenCanvases(), "Actual canvas has some changes.");
        }
    }
}
