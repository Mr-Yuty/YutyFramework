using YutyFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrairies
{
    public class Home : BasePageObject

    {
        private const string searchTextXpath = @"//input[@type='search' and @class='et-search-field']";
        private const string Url = @"https://www.ultimateqa.com/";
        private IWebElement TopSearchLen => Driver.FindElement(By.Id(@"et_top_search"));
        private IWebElement TopSearchField => Driver.FindElement(By.XPath(searchTextXpath));
        
        

        public Home (IWebDriver driver) : base (driver){ }
        public void GoToUrl()
        {
            Driver.Navigate().GoToUrl(Url);
        }
        public void ClickOnSearchLen()
        {
            TopSearchLen.Click();
        }
        public void SearchText(string text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(searchTextXpath)));
            TopSearchField.SendKeys(text + Keys.Enter);
        }

    }
}
