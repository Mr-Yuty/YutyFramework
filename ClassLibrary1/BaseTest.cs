using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace YutyFramework
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver { get; private set; }
        [SetUp]
        public void InitialisationForAllTest()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
        [TearDown]
        public void TestDownForEveryTest()
        {
            if (Driver != null)
                Driver.Close();
                Driver.Quit();
        }

    }
}
