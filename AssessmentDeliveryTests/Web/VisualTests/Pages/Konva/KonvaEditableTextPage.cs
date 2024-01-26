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

        private IWebElement CanvasElement => WebElementWaiting.WaitElement(By.TagName("canvas"));

        public KonvaEditableTextPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {
        }

        public void ScrollToComplexDemoTextElement()
        {
            WebElementActions.MoveToElement(ComplexDemoTextElement);
        }

        public void PutTextIntoCanvasElement(string text)
        {
            Driver.SwitchTo().Frame(EditableTextFrame);

            WebElementActions.MoveToElement(CanvasElement);

            var startPointElement = WebElementActions.GetStartPointOfElement(CanvasElement);

            new Actions(Driver).
                MoveByOffset(startPointElement.X + 130, startPointElement.Y + 60).
                Release().
                Build().
                Perform();

            new Actions(Driver).
                DoubleClick().
                Release().
                Build().
                Perform();

            new Actions(Driver).
                KeyDown(Keys.Control).
                SendKeys("a").
                KeyUp(Keys.Control).
                SendKeys(Keys.Backspace).
                Release().
                Build().
                Perform();

            new Actions(Driver).
                SendKeys(text).
                Release().
                Build().
                Perform();

            new Actions(Driver).
                SendKeys(Keys.Enter).
                Release().
                Build().
                Perform();
        }
    }
}
