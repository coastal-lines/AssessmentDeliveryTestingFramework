﻿using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using AssessmentDeliveryTestingFramework.Core.Logging;

namespace AptitudeTests.Utils
{
    public class AdsPopupObserver
    {
        private AndroidDriver _driver;

        private static Thread _additionalScreenThread;

        private bool _isPopup = true;

        public AdsPopupObserver(AndroidDriver driver)
        {
            _driver = driver;
        }

        public void StartAdsMonitor()
        {
            _additionalScreenThread = new Thread(MonitorAdditionalScreens);

            _additionalScreenThread.Start();

            _additionalScreenThread.Join();
        }

        public void MonitorAdditionalScreens()
        {
            while (_isPopup)
            {
                try
                {
                    if (_driver.FindElements(By.XPath("//android.widget.Button[@text='Update']")).FirstOrDefault().Displayed)
                    {
                        byte[] imageArray = File.ReadAllBytes(@"Resources\CloseAdsButton.jpg");
                        string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                        var imgEl2 = _driver.FindElement(MobileBy.Image(base64ImageRepresentation));
                        imgEl2.Click();

                        _isPopup = false;
                    }
                }
                catch (Exception)
                {
                    Logger.LogInformation("Error while additional thread for waiting adv screen.");
                }

                Thread.Sleep(200);
            }
        }
    }
}
