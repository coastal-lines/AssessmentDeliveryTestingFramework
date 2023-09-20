using AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils;
using AssessmentDeliveryTestingFramework.Core.Utils.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Browsers.Min
{
    public abstract class ElectronBrowserFeatures
    {
        protected const string CONTENT_TYPE = "text/html";

        protected string navigationWindow;

        protected string documentWindow;

        protected IWebDriver driver;

        protected JsExecutorUtils jsUtils;

        public ElectronBrowserFeatures(IWebDriver driver)
        {
            this.driver = driver;

            jsUtils = new JsExecutorUtils(driver);

            //navigationWindow = GetWindowHandle(ConfigManager.Config.MinBrowser.NavigationPageUrl);

            //documentWindow = GetWindowHandle(ConfigManager.Config.MinBrowser.DocumentPageUrl);

            navigationWindow = GetWindowHandle(ConfigurationManager.GetConfigurationModel().Web.MinBrowser.NavigationPageUrl);

            documentWindow = GetWindowHandle(ConfigurationManager.GetConfigurationModel().Web.MinBrowser.DocumentPageUrl);
        }

        private string GetContentType()
        {
            return jsUtils.DoScriptAndReturnResult("document.contentType;");
        }

        protected string GetWindowHandle(string pageName)
        {
            for (int i = 0; i < driver.WindowHandles.Count; i++)
            {
                driver.SwitchTo().Window(driver.WindowHandles[i]);

                if (driver.Url.Contains(pageName) && GetContentType().Equals(CONTENT_TYPE))
                {
                    return driver.WindowHandles[i];
                }
            }

            throw new ArgumentNullException("Electron window was not found");
        }

        protected virtual void SwitchIntoDocument() { }

        protected virtual void SwitchIntoNavigation() { }

        public virtual void NavigateToUrl(string url) { }
    }
}
