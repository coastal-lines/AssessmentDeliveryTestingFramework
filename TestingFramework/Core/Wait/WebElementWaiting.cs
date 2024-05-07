using TestingFramework.Core.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;

namespace TestingFramework.Core.Wait
{
    public class WebElementWaiting : ElementWaiting<IWebDriver>
    {
        public WebElementWaiting(IWebDriver webDriver) : base(webDriver)
        {

        }

        public IWebElement WaitElement(By locator)
        {
            var elements = WaitElements(locator);

            if (elements.Count == 1)
            {
                return WaitElements(locator)[0];
            }
            else if (elements.Count > 1)
            {
                Console.WriteLine($"Page has more than one element for '{locator}' locator.");

                return WaitElements(locator)[0];
            }

            string errorMessage = $"Page doesn't have any element with '{locator}' locator.";
            Logger.LogError(errorMessage, new NoSuchElementException(errorMessage));
            throw new NoSuchElementException(errorMessage);
        }

        public IList<IWebElement> WaitElements(By locator)
        {
            CreateWaiting().Until(ExpectedConditions.ElementToBeClickable(locator));

            CreateWaiting().Until(driver => driver.FindElements(locator).FirstOrDefault().Displayed);

            return CreateWaiting().Until(driver => driver.FindElements(locator));
        }

        public IList<IWebElement> ForceCustomWaitElements(By locator, Func<IWebDriver, By, bool> condition, int waitTimeout = 30)
        {
            var wait = CreateWaiting();

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            while (stopWatch.Elapsed.TotalSeconds <= waitTimeout)
            {
                try
                {
                    Thread.CurrentThread.Join(DefaultPollingInterval);

                    if (wait.Until(driver => condition(GetDriver(), locator)))
                    {
                        stopWatch.Stop();
                        break;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Logger.LogError($"Element {locator} was not found.", ex);
                    throw;
                }
                catch (WebDriverTimeoutException ex)
                {
                    Logger.LogError($"Element timeout waiting. Element is '{locator}'.", ex);
                    throw;
                }
            }

            stopWatch.Stop();

            if (stopWatch.Elapsed.TotalSeconds > waitTimeout)
            {
                string errorMessage = $"Timeout waiting. Element is '{locator}'.";
                Logger.LogError(errorMessage, new Exception(errorMessage));
                throw new Exception(errorMessage);
            }

            return GetDriver().FindElements(locator);
        }

        public IList<IWebElement> CustomWaitElements(By locator, Func<IWebDriver, By, bool> condition)
        {
            var wait = CreateWaiting();

            try
            {
                wait.Until(driver => condition(driver, locator));

                return GetDriver().FindElements(locator);
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError($"Element {locator} was not found.", ex);
                throw;
            }
            catch (WebDriverTimeoutException ex)
            {
                Logger.LogError($"Element timeout waiting. Element is '{locator}'.", ex);
                throw;
            }
        }

        public void WaitElementDisplayed(By by)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(base.GetDriver(), TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError("Element with locator '" + by + "' is not displayed", ex);
                throw;
            }
        }

        public void WaitElementDisappear(By by, int waitingTime = 30)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(base.GetDriver(), TimeSpan.FromSeconds(waitingTime));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (NoSuchElementException ex)
            {
                Logger.LogError("Element with locator '" + by + "' is displayed", ex);
                throw;
            }
        }
    }
}
