using YutyFramework;
using OpenQA.Selenium;

namespace SampleApplication
{
    public class UltimateQAHomePage : BasePageObject
    {
        public UltimateQAHomePage(IWebDriver driver) : base (driver) { }

        public bool IsVisible => Driver.Title.Contains("Home - Ultimate QA");
    }
}