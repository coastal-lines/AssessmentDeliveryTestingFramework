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

        public string ExecuteJS(IWebDriver driver, string script, IWebElement element)
        {
            var js = (IJavaScriptExecutor)driver;

            return (string)js.ExecuteScript(script, element);
        }

        public void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            ExecuteJS(driver, "return arguments[0].scrollIntoView(true);", element);
        }
    }
}