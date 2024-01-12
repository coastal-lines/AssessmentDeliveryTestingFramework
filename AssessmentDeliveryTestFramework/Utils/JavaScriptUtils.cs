using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class JavaScriptUtils
    {
        public string ExecuteJS(IWebDriver driver, string script)
        {
            var js = (IJavaScriptExecutor)driver;

            return (string)js.ExecuteScript(script);
        }
    }
}