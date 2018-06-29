using System;
using OpenQA.Selenium;
using YutyFramework;

namespace reporting
{
    public class ContactUsPage : BasePageObject
    {
        public ContactUsPage(IWebDriver driver) : base(driver) { }
        private IWebElement ContactUsTitleLabel => Driver.FindElement(By.XPath("//h1[@class='page-heading bottom-indent']"));
        private IWebElement FormSendButton => Driver.FindElement(By.Id("submitMessage"));
        public  bool ElementsAreVisible()
        {
            try
            {
                return ContactUsTitleLabel.Displayed && FormSendButton.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}