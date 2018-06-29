using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace YutyFramework
{
    [TestFixture]
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }
        protected IWebDriver Driver { get; private set; }

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        [OneTimeSetUp]
        public void Init()
        {

            Reporter.StartReporter();
        }

        [SetUp]
        public void InitialisationForAllTest()
        {
            this.TestContext = NUnit.Framework.TestContext.CurrentContext;
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            Driver = WebDriverFactory.GetDriver(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }
        [TearDown]
        public void TestDownForEveryTest()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.Test.Name);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }
        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

    }

}
