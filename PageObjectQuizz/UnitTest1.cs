using System;
using YutyFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjectLibrairies;
using PageObjectLibrairies.OpenQA;

namespace PageObjectQuizz
{
    [TestClass]
    public class UnitTest1 
    {
        private IWebDriver Driver;

        [TestMethod]
        public void TestMethod1()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Home home = new Home(Driver);
            SearchResults searchResults = new SearchResults(Driver);
            home.GoToUrl();
            home.ClickOnSearchLen();
            home.SearchText("complicated page");
            searchResults.ClickOnResult("Complicated Page");
            Driver.Close();
            Driver.Quit();
            Driver.FindElements(By.Id(""))[0].SendKeys("lol");
        }
       
    }
    
}
