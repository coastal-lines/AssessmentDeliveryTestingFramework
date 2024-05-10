using CanvasTests.Pages;
using NUnit.Framework;
using System.Drawing;
using CanvasTests.Pages.Konva;
using TestingFramework.Core.TestManagement.Extensions.NUnit;
using TestingFramework.Core.TestManagement;

namespace CanvasTests.Tests
{
    internal class EditableTextItemsTests : WebPageObject
    {
        private const string _canvasText = "Some text here";

        private const string _url = "https://konvajs.org/docs/sandbox/Editable_Text.html";

        private Size _pageSize = new Size(765, 900);

        /// <summary>
        /// Tested on the 1600*900 screen resolution.
        /// </summary>
        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        [Description("TC1 - KonvaJS - Interract by coordinates and compare by screenshots")]
        public void TС1KonvaJSInterractByCoordinates()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl(_url);
            Session.GetDriver().Manage().Window.Size = _pageSize;

            //Step 2
            var konvaEditableTextPage = new KonvaEditableTextPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaEditableTextPage.ScrollToComplexDemoTextElement();

            //Step 3
            konvaEditableTextPage.PutTextIntoCanvasElement(130, 60, "Canvas test");

            //Step 4
            Assert.IsTrue(konvaEditableTextPage.IsDifferenceBetweenCanvases(), "Actual canvas has some changes. Please check TeamCity artifacts.");
        }

        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        [Description("TC2 - KonvaJS - Interract and compare by JS")]
        public void TС2KonvaJSInterractByJS()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl(_url);
            Session.GetDriver().Manage().Window.Size = _pageSize;

            //Step 2
            var konvaEditableTextPage = new KonvaEditableTextPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaEditableTextPage.ScrollToComplexDemoTextElement();

            //Step 3
            var canvasText = konvaEditableTextPage.GetTextFromCanvasElement();
            Assert.AreEqual(_canvasText, canvasText, $"Canvas has '{canvasText}' text but text should be '{_canvasText}'");
        }
    }
}