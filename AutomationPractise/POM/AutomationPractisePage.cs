using System;
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

        public AutomationPractisePage(IWebDriver driver) : base(driver) {
            Slider = new Slider(driver);
        }

        public SearchResultPage SearchFor(string textToSearch)
        {
            SearchBarField.SendKeys(textToSearch);
            SearchBarButton.Click();
            return new SearchResultPage(Driver);
        }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(Url);
            Assert.IsTrue(IsVisible, "The page AutomationPractice is not visible");
        }

        public ContactUsPage ClickContact()
        {
            ContactUsLink.Click();
            return new ContactUsPage(Driver); 
        }
    }
}