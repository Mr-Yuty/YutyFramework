using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;

namespace YutyFramework
{
    public static class Reporter
    {
        private static readonly Logger TheLogger = LogManager.GetCurrentClassLogger();
        private static ExtentReports ReportManager { get; set; }
        private static string ApplicationDebuggingFolder => "c://temp/CreatingReports";

        private static string HtmlReportFullPath { get; set; }

        public static string LatestResultsReportFolder { get; set; }

        private static TestContext MyTestContext { get; set; }

        private static ExtentTest CurrentTestCase { get; set; }

        public static void StartReporter()
        {
            TheLogger.Trace("Starting a one time setup for the entire" +
                            " .CreatingReports namespace." +
                            "Going to initialize the reporter next...");
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);
        }

        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            var currentProject = TestContext.CurrentContext.TestDirectory.Split('\\')[3];
            LatestResultsReportFolder = Path.Combine(filePath, currentProject, DateTime.Now.ToString(" - MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);

            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            TheLogger.Trace("Full path of HTML report=>" + HtmlReportFullPath);
        }

        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.Test.Name);
        }

        public static void LogPassingTestStepToBugLogger(string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.Result.Outcome.Status;

            switch (status)
            {
                case TestStatus.Failed:
                    TheLogger.Error($"Test Failed=>{MyTestContext.Test.FullName}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail - " + MyTestContext.Result.Message);
                    break;
                case TestStatus.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive - " + MyTestContext.Result.Message);
                    break;
                case TestStatus.Skipped:
                    CurrentTestCase.Skip("Test skipped - " + MyTestContext.Result.Message);
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            TheLogger.Info(message);
            CurrentTestCase.Log(status, message);
        }
    }
}
