using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Session;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasTests.Pages.Konva
{
    internal class KonvaEditableTextPage : WebBasePage
    {
        private IWebElement ComplexDemoTextElement => WebElementWaiting.WaitElement(By.XPath("//p[contains(text(), 'Complex demo:')]"));

        private IWebElement EditableTextFrame => WebElementWaiting.WaitElement(By.CssSelector(".page-entry > iframe:nth-of-type(1)"));

        public KonvaEditableTextPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {
        }

        public void ScrollToComplexDemoTextElement()
        {
            WebElementActions.MoveToElement(ComplexDemoTextElement);
        }

        public void PutTextIntoCanvasElement()
        {
            var xZero1 = -(Driver.Manage().Window.Size.Width / 2);
            var yZero1 = -(Driver.Manage().Window.Size.Height / 2);

            Driver.SwitchTo().Frame(EditableTextFrame);

            var xZero = -(Driver.FindElement(By.TagName("body")).Size.Width / 2);
            var yZero = -(Driver.FindElement(By.TagName("body")).Size.Height / 2);

            new Actions(Driver).
                MoveByOffset(0, 0).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Driver).
                MoveByOffset(xZero + 135, yZero + 60).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Driver).
                MoveByOffset(xZero1 + 135, yZero1 + 60).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Driver).
                MoveByOffset(xZero + 135, yZero + 60).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Driver).
                MoveByOffset(xZero + 135, yZero + 60).
                DoubleClick().
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                SendKeys("Click by coordinates").
                Release().
                Build().
                Perform();

            //WebElementActions.MoveToElementByCoordinatesAndRemoveTextAndSendTextByKeys(xZero + 135, yZero + 60, "Click by coordinates");
        }
    }
}
