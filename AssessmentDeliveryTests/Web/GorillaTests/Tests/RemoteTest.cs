﻿using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorillaTests.Tests
{
    internal class RemoteTest
    {
        [Test]
        public void RemoteTestFirefox()
        {
            var options = new FirefoxOptions();
            //var driver = new RemoteWebDriver(new Uri("http://ip:port"), options);
            var driver = new RemoteWebDriver(new Uri("http://ip:port"), options);
            driver.Navigate().GoToUrl("https://stackoverflow.com/questions/10607806/bind-selenium-to-a-specific-ip-possible");
        }

        /*
        [Test]
        public void TestFirefox()
        {
            var options = new FirefoxOptions();
            var driver = new RemoteWebDriver(new Uri("http://ip:port"), options);
            driver.Navigate().GoToUrl("https://stackoverflow.com/questions/10607806/bind-selenium-to-a-specific-ip-possible");
        }

        [Test]
        public void RemoteTestChrome()
        {
            var options = new ChromeOptions();
            var driver = new RemoteWebDriver(new Uri("http://ip:port"), options);
            driver.Navigate().GoToUrl("https://stackoverflow.com/questions/10607806/bind-selenium-to-a-specific-ip-possible");
        }
        */
    }
}
