using OpenQA.Selenium;

namespace AssessmentDeliveryTestingFramework.Utils
{
    public class JavaScriptUtils
    {
        public string ExecuteJS(IWebDriver driver, string script)
        {
            var js = (IJavaScriptExecutor)driver;
            var result = js.ExecuteScript(script);

            return result.ToString();
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

        public int GetVerticalDifferenceBetweenTopAndCurrentPagePosition(IWebDriver driver)
        {
            var result = ExecuteJS(driver, "return window.scrollY");
            return Int16.Parse(result);
        }
    }
}