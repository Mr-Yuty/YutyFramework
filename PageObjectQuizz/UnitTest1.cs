using YutyFramework;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjectLibrairies;
using PageObjectLibrairies.OpenQA;

namespace PageObjectQuizz
{
    [TestFixture]
    public class UnitTest1 : BaseTest
    {

        [Test]
        public void TestMethod1()
        {
            Home home = new Home(Driver);
            SearchResults searchResults = new SearchResults(Driver);
            home.GoToUrl();
            home.ClickOnSearchLen();
            home.SearchText("complicated page");
            searchResults.ClickOnResult("Complicated Page");
            Driver.FindElements(By.Id(""))[0].SendKeys("lol");
        }
       
    }
    
}
