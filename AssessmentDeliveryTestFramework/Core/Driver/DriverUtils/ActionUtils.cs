using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDeliveryTestingFramework.Core.Driver.DriverUtils
{
    public class AndroidActions
    {
        private AndroidDriver _driver;

        public AndroidActions(AndroidDriver driver)
        {
            _driver = driver;
        }

        public void SwipeRight()
        {
            int screenWidth = _driver.Manage().Window.Size.Width;
            int screenHeight = _driver.Manage().Window.Size.Height;

            int startX = (int)(screenWidth * 0.1);
            int endX = (int)(screenWidth * 0.9);
            int startY = screenHeight / 2;

            var touchAction = new TouchAction(_driver);
            touchAction.Press(startX, startY)
                .Wait(100) // Optional: Add a wait time to control the speed of the swipe
                .MoveTo(endX, startY)
                .Release()
                .Perform();
        }

        public void SwipeLeft()
        {
            int screenWidth = _driver.Manage().Window.Size.Width;
            int screenHeight = _driver.Manage().Window.Size.Height;

            int startX = (int)(screenWidth * 0.9);
            int endX = (int)(screenWidth * 0.1);
            int startY = screenHeight / 2;

            var touchAction = new TouchAction(_driver);
            touchAction.Press(startX, startY)
                .Wait(500) // Optional: Add a wait time to control the speed of the swipe
                .MoveTo(endX, startY)
                .Release()
                .Perform();
        }
    }

    public class ActionUtils
    {
        public void GetCentreOfScreen(IWebDriver driver)
        {

        }
    }
}
