using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeQuizMakerTests.Pages.FreeQuizMakerExams.ControlsPane.Menu
{
    internal class FileMenuPage : MenuPage
    {
        private IWebDriver _driver;

        private IWebElement NewQuizItem => FileMenu.FindElement(By.XPath("//MenuItem[@Name='New Quiz']"));

        private IWebElement OpenQuizItem => FileMenu.FindElement(By.XPath("//MenuItem[@Name='Open Quiz']"));

        private IWebElement SaveQuizItem => FileMenu.FindElement(By.XPath("//MenuItem[@Name='Save Quiz']"));

        private IWebElement PublishQuizItem => FileMenu.FindElement(By.XPath("//MenuItem[@Name='Publish Quiz']"));

        private IWebElement ExportQuizHtmlItem => _driver.FindElement(By.XPath("//MenuItem[@Name='File']//MenuItem[@Name='Export Quiz Html...']"));

        private IWebElement ExitItem => FileMenu.FindElement(By.XPath("//MenuItem[@Name='Exit']"));



        public FileMenuPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void ExportQuizHtmlItemClick()
        {
            try
            {
                ExportQuizHtmlItem.Click();
            }
            catch (Exception ex)
            {
                new Actions(_driver).MoveToElement(FileMenu.FindElements(By.XPath("//*"))[6]).MoveByOffset(5, 5).Click().Perform();
            }
        }
    }
}
