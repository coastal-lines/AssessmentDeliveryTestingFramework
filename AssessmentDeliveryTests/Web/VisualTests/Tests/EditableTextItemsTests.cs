using CanvasTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasTests.Tests
{
    internal class EditableTextItemsTests : WebPageObject
    {
        [Test]
        [Description("TC1 - KonvaJS - Interract by coordinates")]
        public void TС1KonvaJSInterractByCoordinates()
        {
            //Step 1
            Session.GetDriver().Navigate().GoToUrl("https://konvajs.org/docs/sandbox/Editable_Text.html");
            Session.GetDriver().Manage().Window.Size = new Size(765, 900);



            //Selenium4
            new Actions(chromeDriver).ScrollToElement(chromeDriver.FindElement(By.XPath("//p[contains(text(), 'Complex demo:')]"))).Perform();

            //Add for video - don't foget to provide information for the team
            //Because this scipt totaly depence on screen resolution
            //So better to put some comments about this
            new Actions(chromeDriver).
                MoveByOffset(165, 435).
                DoubleClick().
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                SendKeys("Click by coordinates").
            Release().
                Build().
                Perform();

            chromeDriver.Close();
            chromeDriver.Quit();

            Assert.Pass();
        }
    }
}
