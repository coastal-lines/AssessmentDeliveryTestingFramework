using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium;

namespace AptitudeTests.Pages.AptitudeExams
{
    public class TopMenuScreen
    {
        private AndroidDriver _androidDriver;

        public TopMenuScreen(AndroidDriver androidDriver)
        {
            _androidDriver = androidDriver;
        }
    }

    public class BottomMenuScreen
    {
        private AndroidDriver _androidDriver;

        public BottomMenuScreen(AndroidDriver androidDriver)
        {
            _androidDriver = androidDriver;
        }
    }

    public class TestMainViewScreen
    {
        private AndroidDriver _androidDriver;

        private IWebElement MainWebViewElement => _androidDriver.FindElement(By.XPath("//android.webkit.WebView"));

        private IWebElement QuestionText => MainWebViewElement.FindElement(By.XPath($"//android.view.View[@text='']"));

        public TestMainViewScreen(AndroidDriver androidDriver)
        {
            _androidDriver = androidDriver;
        }
    }

    public class TestScreen
    {
        private AndroidDriver _androidDriver;

        public TestScreen(AndroidDriver androidDriver)
        {
            _androidDriver = androidDriver;
        }
    }
}
