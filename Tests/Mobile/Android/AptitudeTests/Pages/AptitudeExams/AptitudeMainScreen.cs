using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using TestingFramework.Core.Wait;
using TestingFramework.Core.Session;

namespace AptitudeTests.Pages.AptitudeExams
{
    public class TestOptionsDialog : MobileAndroidBasePage
    {
        //private AndroidDriver _androidDriver;

        private IWebElement NormalButton => WebElementWaiting.WaitElement(By.Id("nithra.math.aptitude:id/normal"));

        public TestOptionsDialog(MobileSession session) : base(session)
        {
            //_androidDriver = androidDriver;
        }

        public void DoNormalTest()
        {
            NormalButton.Click();
        }
    }

    public class TestMainScreen : TestOptionsDialog
    {
        //private AndroidDriver _androidDriver;

        private IWebElement StartButton => WebElementWaiting.WaitElement(By.Id("nithra.math.aptitude:id/txtStart"));

        public TestMainScreen(MobileSession session) : base(session)
        {
            //_androidDriver = androidDriver;
        }

        public void StartTest()
        {
            StartButton.Click();
        }

        public TestScreen SelectTest(string testName)
        {
            WebElementWaiting.WaitElement(By.XPath($"//android.widget.CheckBox[@text='{testName}']")).Click();

            StartTest();
            DoNormalTest();

            return new TestScreen(Driver);
        }
    }

    public class TakeATestDialog : MobileAndroidBasePage
    {
        //private AndroidDriver _androidDriver;

        //private IWebElement TestButton => _androidDriver.FindElement(By.Id("nithra.math.aptitude:id/lin_test"));
        private IWebElement TestButton => WebElementWaiting.WaitElement(By.Id("nithra.math.aptitude:id/lin_test"));

        public TakeATestDialog(MobileSession session) : base(session)
        {
            //_androidDriver = session.GetDriver();
        }

        public void SelectTestType()
        {
            TestButton.Click();
        }
    }

    public class AptitudeMainScreen : TakeATestDialog
    {
        private AndroidDriver _androidDriver;

        #region Pages

        private TestMainScreen _testMainScreen;

        public TestMainScreen TestMainScreen => _testMainScreen;

        #endregion

        #region Elements

        private IWebElement TakeATestButton => _androidDriver.FindElement(By.Id("nithra.math.aptitude:id/test_dialog"));

        #endregion

        public AptitudeMainScreen(MobileSession session) : base(session)
        {
            _androidDriver = session.GetDriver();

            _testMainScreen = new TestMainScreen(session);
        }

        public void OpenTestDialog()
        {
            TakeATestButton.Click();
        }

        public TestScreen OpenTest(string testName)
        {
            OpenTestDialog();

            SelectTestType();

            return TestMainScreen.SelectTest(testName);
        }
    }
}
