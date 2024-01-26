using AssessmentDeliveryTestingFramework.Core.Element.Web;
using AssessmentDeliveryTestingFramework.Core.Wait;
using OpenQA.Selenium;
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

        public KonvaEditableTextPage(IWebDriver driver, WebElementWaiting webElementWaiting, WebElementActions webElementActions) : base(driver, webElementWaiting, webElementActions)
        {
        }

        public void ScrollToComplexDemoTextElement()
        {
            WebElementActions.MoveToElement(ComplexDemoTextElement);
        }
    }
}
