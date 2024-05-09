using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace TestingFramework.Core.Browsers.Min
{
    public class MinBrowserFeatures : ElectronBrowserFeatures
    {
        private IWebElement _tabsElement => driver.FindElement(By.Id("tabs-inner"));

        private IWebElement _tabInputElement => driver.FindElement(By.Id("tab-editor-input"));

        public MinBrowserFeatures(IWebDriver driver) : base(driver) { }

        private void OpenNavigationInput()
        {
            _tabsElement.Click();

            _tabInputElement.Click();
        }

        private void CleanNavigationInput()
        {
            new Actions(driver).KeyDown(Keys.LeftControl).SendKeys("a").KeyDown(Keys.Backspace).Perform();

            _tabInputElement.SendKeys(Keys.Backspace);
        }

        protected override void SwitchIntoDocument()
        {
            driver.SwitchTo().Window(documentWindow);
            //Some browser's specific waits
        }

        protected override void SwitchIntoNavigation()
        {
            driver.SwitchTo().Window(navigationWindow);
            //Some browser's specific waits
        }

        public override void NavigateToUrl(string url)
        {
            SwitchIntoNavigation();

            OpenNavigationInput();
            CleanNavigationInput();

            _tabInputElement.SendKeys(url);
            _tabInputElement.SendKeys(Keys.Enter);

            SwitchIntoDocument();
        }
    }
}
