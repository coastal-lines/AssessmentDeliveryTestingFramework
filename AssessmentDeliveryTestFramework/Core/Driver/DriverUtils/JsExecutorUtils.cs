using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils
{
    public class JsExecutorUtils
    {
        private IWebDriver _driver;

        public JsExecutorUtils(IWebDriver driver)
        {
            _driver = driver;
        }

        public string DoScriptAndReturnResult(string script)
        {
            var js = (IJavaScriptExecutor)_driver;
            return (string)js.ExecuteScript($"return {script}");
        }
    }
}
