using OpenQA.Selenium;

namespace TestingFramework.Core.Wait
{
    public class ElementWaiting<TDriver> : ElementWaitFactory<IWebDriver>
    {
        public static Func<IWebDriver, By, bool> IsElementsSelected = IsSelected;

        public ElementWaiting(TDriver driver) : base((IWebDriver)driver)
        {

        }

        private static bool IsSelected(IWebDriver driver, By locator)
        {
            return driver.FindElements(locator).FirstOrDefault().Selected;
        }
    }
}
