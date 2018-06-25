using System;
using System.Threading;
using OpenQA.Selenium;
using YutyFramework;

namespace AutomationPractise
{
    public class Slider : BasePageObject
    {
        public Slider(IWebDriver driver) : base(driver) { }

        public string GetCurrentImage()
        {
            return Driver.FindElement(By.Id("homeslider")).GetAttribute("style");
        }

        public void ClickNext()
        {
            Driver.FindElement(By.LinkText("Next")).Click();
        }
    }
}