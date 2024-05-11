using AptitudeTests.Pages.AptitudeExams;
using TestingFramework.Core.Session;
using TestingFramework.Core.Wait;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptitudeTests.Pages.Android
{
    public class MainScreen : MobileAndroidBasePage
    {
        //private AndroidDriver _androidDriver;

        private IWebElement AptitudeTestIcon => WebElementWaiting.WaitElement(By.XPath("//android.widget.TextView[@text='Aptitude Test']"));

        //private IMobileElement AptitudeTestIcon => (IMobileElement)WebElementWaiting.WaitElement(By.XPath("//Edit[@AutomationId='txtQuestion']"));

        public MainScreen(MobileSession session) : base(session)
        {
            //_androidDriver = androidDriver;
        }

        public AptitudeMainScreen OpenAptitude()
        {
            AptitudeTestIcon.Click();

            return new AptitudeMainScreen(Session);
        }
    }
}
