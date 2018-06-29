using System;
using NLog;
using NUnit.Framework;
using OpenQA.Selenium;
using YutyFramework;

namespace AutomationPractise
{
    public class AutomationPractisePage : BasePageObject
    {
        private const string Url = "http://automationpractice.com/index.php";
        private IWebElement SearchBarField => Driver.FindElement(By.Id("search_query_top"));
        private IWebElement SearchBarButton => Driver.FindElement(By.Name("submit_search"));
        private IWebElement ContactUsLink => Driver.FindElement(By.LinkText("Contact us"));

        public bool IsVisible { get { return Driver.Title== "My Store"; } private set { } }

        public Slider Slider { get; internal set; }
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public AutomationPractisePage(IWebDriver driver) : base(driver) {
            Slider = new Slider(driver);
        }

        public SearchResultPage SearchFor(string textToSearch)
        {
            SearchBarField.SendKeys(textToSearch);
            _logger.Info("Sent the keys iwiejfwoeijf to the field erfjo3wifj");
            SearchBarButton.Click();
            return new SearchResultPage(Driver);
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            _logger.Info("werjweifuj");
            _logger.Debug("debug");
            _logger.Error("error");
            _logger.Fatal("fatal");
            _logger.Trace("trace");

            
            Assert.IsTrue(IsVisible, "The page AutomationPractice is not visible");
        }

        public ContactUsPage ClickContact()
        {
            ContactUsLink.Click();
            return new ContactUsPage(Driver); 
        }
    }
}