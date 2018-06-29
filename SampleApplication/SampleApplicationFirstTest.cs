using System.IO;
using System.Reflection;
using DataObjectLibrairies;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using YutyFramework;

namespace SampleApplication
{

    [TestFixture, Description("test application sprint 2")]
    [Parallelizable]
    [Category("test application sprint 2")]
    [Author("Yuty")]
    public class SampleApplicationFirstTest :BaseTest
    {
        public TestUser TheTestUser { get; private set; }
        public TestUser TheOtherTestUser { get; private set; }
        public SampleApplicationPage SampleApplicationPage { get; private set; }

        [SetUp]
        public void TestInit()
        {
            TheTestUser = new TestUser(Personat.YoungGuy);
            TheOtherTestUser = new TestUser(Personat.SJW);
            SampleApplicationPage = new SampleApplicationPage(Driver);
        }
   
        [Test]
        [Category("batch 1")]
        public void Sapp_TC01()
        {
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyForm(TheOtherTestUser);
            var ultimateQAHomePage = SampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            AssertIsVisible(ultimateQAHomePage);
        }

        [Test]
        [Category("batch 2")]
        public void Sapp_TC02()
        {
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyForm(TheOtherTestUser);
            var ultimateQAHomePage = SampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            AssertVariation(ultimateQAHomePage);
        }
        [Test]
        public void Sapp_TC03()
        {
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyForm(TheTestUser);
            var ultimateQAHomePage = SampleApplicationPage.FillOutFormAndSubmit(TheOtherTestUser);
            AssertVariation(ultimateQAHomePage);
        }
        [Test]
        public void Sapp_TC04()
        {
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyForm(TheTestUser);
            var ultimateQAHomePage = SampleApplicationPage.FillOutFormAndSubmit(TheOtherTestUser);
            AssertVariation(ultimateQAHomePage);
        }

        private static void AssertVariation(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsFalse(!ultimateQAHomePage.IsVisible, "Ultimate QA Page was not visible");
        }
        private static void AssertIsVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA Page was not visible");
        }

        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
        
    }

}
