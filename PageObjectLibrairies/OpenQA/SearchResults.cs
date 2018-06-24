using YutyFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PageObjectLibrairies.OpenQA
{
    public class SearchResults : BasePageObject
    {
        private IWebElement ComplicatedPageLink => Driver.FindElement(By.LinkText("Complicated Page"));
        public SearchResults(IWebDriver driver) : base(driver){ }

        public void ClickOnResult(string ResultLinkName)  
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ResultLinkName)));
            Driver.FindElement(By.LinkText(ResultLinkName)).Click();
        }

    }
}
