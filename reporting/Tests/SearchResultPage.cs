using System;
using OpenQA.Selenium;
using YutyFramework;

namespace reporting
{
    public class SearchResultPage : BasePageObject
    {
        private IWebElement SearchResultTitle => Driver.FindElement(By.XPath("//h1[@class='page-heading  product-listing']"));
        public SearchResultPage(IWebDriver driver) : base(driver) {  }

        public bool IsVisible { get { return SearchResultTitle.Displayed; } private set { } }

        public bool Contains(Item item)
        {
            try
            {
                switch (item)
                {
                    case Item.Blouse:
                        if(this.IsVisible && Driver.FindElement(By.LinkText("Blouse")).Displayed)
                        {
                            Reporter.LogPassingTestStepToBugLogger("Search result does contain : " + Item.Blouse.ToString());
                            return true;
                        }
                        return false;
                    default:
                        throw new ArgumentException("There is no such item");
                }


            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }
    }
}