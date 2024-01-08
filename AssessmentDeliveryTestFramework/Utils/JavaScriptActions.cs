using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class JavaScriptActions
    {
        public bool IsScrollBarPresentedJS(IWebDriver driver)
        {
            var jsExecutor = driver as IJavaScriptExecutor;
            string result = Convert.ToString(jsExecutor.ExecuteScript(@"let nda = document.querySelector('.confirmation-container'); return nda.clientHeight < nda.scrollHeight;"));

            return Boolean.Parse(result);
        }
    }
}
