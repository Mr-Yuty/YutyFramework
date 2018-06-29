using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YutyFramework
{
    public class BasePageObject
    {
        protected WebDriverWait Wait => new WebDriverWait(Driver, TimeSpan.FromSeconds(15));

        protected IWebDriver Driver { get; set; }

        public BasePageObject(IWebDriver driver)
        {
            this.Driver = driver;
        }
        protected void SetWaitTimeInSeconds(int time)
        {
            Wait.Timeout = TimeSpan.FromSeconds(time);
        }
    }
}
