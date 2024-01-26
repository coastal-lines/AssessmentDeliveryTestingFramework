using CanvasTests.Pages;
using NUnit.Framework;
using System.Drawing;
using CanvasTests.Pages.Konva;
using AssessmentDeliveryTestingFramework.Core.TestManagement.Extensions.NUnit;
using AssessmentDeliveryTestingFramework.Core.TestManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using AssessmentDeliveryTestingFramework.Core.Element.Web;
using MathNet.Numerics.LinearAlgebra;

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
            /*
             * MoveByOffset docs
             * Before any action, moving, etc - start point is left top corner
             * After any action, moving, scroll, etc - start point is the center of the latest active element
             * For reset start point - find "body" element and substract coordinates of the center of body element 
            */

            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Editable_Text.html");
            Session.GetDriver().Manage().Window.Size = new Size(765, 900);

            //Step 2
            var konvaEditableTextPage = new KonvaEditableTextPage(Session.GetDriver(), Session.WebElementWaiting, Session.WebElementActions);
            konvaEditableTextPage.ScrollToComplexDemoTextElement();

            Thread.Sleep(3000);

            var iframe = Session.GetDriver().FindElement(By.XPath("/html/body/article/div/div[2]/div[1]/iframe[1]"));
            Session.GetDriver().SwitchTo().Frame(iframe);
            var canvas = Session.GetDriver().FindElement(By.TagName("canvas"));
            var xZero = -(canvas.Size.Width / 2);
            var yZero = -(canvas.Size.Height / 2);

            Session.WebElementActions.MoveToElement(canvas);
            //new Actions(Session.GetDriver()).MoveByOffset(xZero + 130, yZero + 60).DoubleClick().Release().Build().Perform();


            new Actions(Session.GetDriver()).
                MoveByOffset(xZero + 130, yZero + 60).
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                SendKeys("Click by coordinates. 9999999999. 888888888888.").
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                SendKeys(Keys.Enter).
                Release().
                Build().
                Perform();

            //Session.WebElementActions.MoveToElementByCoordinatesAndRemoveTextAndSendTextByKeys(160, 425, "Click by coordinates");



            //konvaEditableTextPage.PutTextIntoCanvasElement();

            //Step 3
            //This step strongly depens on the page size
            //Add for video - don't foget to provide information for the team
            //Because this scipt totaly depence on screen resolution
            //So better to put some comments about this



            Assert.Pass();
        }


        [Test]
        [NonParallelizable]
        [BrowserType("Chrome")]
        [Category(TestType.Web)]
        public void Ttttrest()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Free_Drawing.html");
            //Session.GetDriver().Manage().Window.Maximize();
            Session.GetDriver().Manage().Window.Size = new Size(765, 900);

            Thread.Sleep(3000);

            Session.WebElementActions.MoveToElement(Session.GetDriver().FindElement(By.XPath("/html/body/article/div/div[2]/div[1]/details[1]/summary")));

            Thread.Sleep(3000);

            var iframe = Session.GetDriver().FindElement(By.XPath("/html/body/article/div/div[2]/div[1]/iframe[1]"));
            Session.GetDriver().SwitchTo().Frame(iframe);
            var canvas = Session.GetDriver().FindElement(By.TagName("canvas"));

            var w = Session.GetDriver().Manage().Window.Size.Width;
            var h = Session.GetDriver().Manage().Window.Size.Height;

            //var xZero = -(iframe.Size.Width / 2);
            //var yZero = -(iframe.Size.Height / 2);
            var xZero = -(canvas.Size.Width / 2);
            var yZero = -(canvas.Size.Height / 2);
            //var xZero = 0;
            //var yZero = 0;

            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 0, yZero + 0).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 10, yZero + 10).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 20, yZero + 20).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 30, yZero + 30).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 40, yZero + 40).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 50, yZero + 50).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 60, yZero + 60).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 70, yZero + 70).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);
            new Actions(Session.GetDriver()).MoveByOffset(xZero + 80, yZero + 80).DoubleClick().Release().Build().Perform();
            Session.WebElementActions.MoveToElement(canvas);


            /*
            new Actions(Session.GetDriver()).
                MoveByOffset(450, 730).
                DoubleClick().
                Release().
                Build().
                Perform();
            */

            /*
            new Actions(Session.GetDriver()).
                MoveByOffset(20, 20).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                MoveByOffset(40, 40).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                MoveByOffset(160, 160).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                MoveByOffset(170, 170).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Session.GetDriver()).
                MoveByOffset(180, 180).
                DoubleClick().
                Release().
                Build().
                Perform();
            */
        }
    }
}
