using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.Android.UiAutomator;
using AngleSharp.Dom;
using System.Threading;
using System.Diagnostics;
using AssessmentDeliveryTestingFramework.Models.Config;
using System.Xml.Linq;
using System.Runtime.InteropServices;

namespace AssessmentDeliveryTestingFramework.Core.Wait
{
    public abstract class ElementWaitFactory<TDriver> where TDriver : IWebDriver
    {
        protected readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        protected readonly TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(300);

        private readonly TDriver driver;

        protected ElementWaitFactory(TDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException("Driver " + nameof(driver) + " is not supported");
        }

        public WebDriverWait Create()
        {
            return new WebDriverWait(GetDriver(), DefaultTimeout)
            {
                PollingInterval = DefaultPollingInterval
            };
        }

        protected TDriver GetDriver()
        {
            return driver;
        }
    }

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

    public class DesktopWindowsElementWaiting : ElementWaiting<WindowsDriver>
    {
        public DesktopWindowsElementWaiting(WindowsDriver webDriver) : base(webDriver)
        {

        }

    }

    public class MobileAndroidElementWaiting : ElementWaiting<AndroidDriver>
    {
        public MobileAndroidElementWaiting(AndroidDriver webDriver) : base(webDriver)
        {

        }
    }

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

            throw new NoSuchElementException($"Page doesn't have any element with '{locator}' locator.");
        }

        public IList<IWebElement> WaitElements(By locator)
        {
            Create().Until(ExpectedConditions.ElementToBeClickable(locator));

            Create().Until(driver => driver.FindElements(locator).FirstOrDefault().Displayed);

            return Create().Until(driver => driver.FindElements(locator));
        }

        public IList<IWebElement> ForceCustomWaitElements(By locator, Func<IWebDriver, By, bool> condition, int waitTimeout = 30)
        {
            var wait = Create();

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
                    Console.WriteLine("Element not found."); // TODO
                    throw;
                }
                catch (WebDriverTimeoutException ex)
                {
                    Console.WriteLine("Timed out after."); //TODO
                    throw;
                }
            }

            stopWatch.Stop();

            if (stopWatch.Elapsed.TotalSeconds > waitTimeout)
            {
                throw new Exception("Element(s) was not found.");
            }

            return GetDriver().FindElements(locator);
        }

        public IList<IWebElement> CustomWaitElements(By locator, Func<IWebDriver, By, bool> condition)
        {
            var wait = Create();

            try
            {
                wait.Until(driver => condition(driver, locator));

                return GetDriver().FindElements(locator);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Element not found."); // TODO
                throw;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Timed out after."); //TODO
                throw;
            }
        }

        public void Test()
        {
            var elements = ForceCustomWaitElements(By.TagName("app-tgo-choice"), ElementWaiting<IWebDriver>.IsElementsSelected, 30);
        }
    }
}
