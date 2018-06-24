using System;
using OpenQA.Selenium;
using YutyFramework;

namespace AutomationPractise
{
    public class SearchResultPage : BasePageObject
    {
        private IWebElement SearchResultTitle => Driver.FindElement(By.XPath("//h1[@class='page-heading  product-listing']"));
        public SearchResultPage(IWebDriver driver) : base(driver) {  }

        public bool IsVisible { get { return SearchResultTitle.Displayed; } private set { } }

        public bool Contains(Item item)
        {
            switch (item)
            {
                case Item.Blouse:
                    return this.IsVisible && Driver.FindElement(By.LinkText("Blouse")).Displayed;
                default:
                    throw new ArgumentException("There is no such item");
            }
        }
    }
}