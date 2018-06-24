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

        public bool IsVisible { get { return Driver.Title== "My Store"; } private set { } }

        public AutomationPractisePage(IWebDriver driver) : base(driver) { }
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
    }
}