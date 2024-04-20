using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane.Menu
{
    internal class MenuPage
    {
        private IWebDriver _driver;

        public IWebElement FileMenu => _driver.FindElement(By.XPath("//MenuItem[@Name='File']"));

        public MenuPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void FileMenuClick()
        {
            FileMenu.Click();
        }
    }
}
