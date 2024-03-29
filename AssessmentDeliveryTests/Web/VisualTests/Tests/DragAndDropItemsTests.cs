﻿using AssessmentDeliveryTestingFramework.Core.Driver.DriverContainers;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Drawing;
using CanvasTests.Pages;
using CanvasTests.Pages.Konva;

namespace CanvasTests.Tests
{
    public class DragAndDropItemsTests : WebPageObject
    {
        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        [Description("TC2 - KonvaJS - Drag and Drop by Sikuli")]
        public void TC2KonvaJSDragAndDropBySikuliTest()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Animals_on_the_Beach_Game.html");
            Session.GetDriver().Manage().Window.Size = new Size(880, 880);

            //Step 2
            var konvaDragAndDropPage = new KonvaDragAndDropPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaDragAndDropPage.ScrollToCanvasElement();

            //Step 3
            konvaDragAndDropPage.MatchAllElementsBySikuli();

            //Step 4
            Assert.IsTrue(konvaDragAndDropPage.IsDifferenceBetweenCanvases(), "Actual canvas has some changes. Please check TeamCity artifacts.");
        }

        /// <summary>
        /// Test works on the primary screen only.
        /// If you have more than one screen, please switch into primary screen and switch off other screens.
        /// </summary>
        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        [Description("TC3 - KonvaJS - Drag and Drop by Appium Image Plugin")]
        public void TC3KonvaJSDragAndDropByImagePluginTest()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Animals_on_the_Beach_Game.html");
            Session.GetDriver().Manage().Window.Maximize();

            //Step 2
            var konvaDragAndDropPage = new KonvaDragAndDropPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaDragAndDropPage.ScrollToCanvasElement();

            //Step 3
            Session.AddAdditionalDesktopContainer("chrome", "Konva");
            var container = (DesktopDriverContainer)Session.GetDriverContainer<DesktopDriverContainer>("Windows");
            konvaDragAndDropPage.MatchAllElementsByAppium(container);

            //Step 4
            var windowsDriver = (WindowsDriver)Session.GetDriverContainer<DesktopDriverContainer>("Windows").Driver;
            Assert.IsTrue(konvaDragAndDropPage.IsDifferenceBetweenScreenshots(windowsDriver), "Actual canvas has some changes. Please check TeamCity artifacts.");
        }
    }
}