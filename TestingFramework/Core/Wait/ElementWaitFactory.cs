using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TestingFramework.Core.Wait
{
    public abstract class ElementWaitFactory<TDriver> where TDriver : IWebDriver
    {
        private readonly TDriver driver;

        protected readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(30);

        protected readonly TimeSpan DefaultPollingInterval = TimeSpan.FromMilliseconds(300);

        protected ElementWaitFactory(TDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException("Driver " + nameof(driver) + " is not supported");
        }

        public WebDriverWait CreateWaiting()
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
}
