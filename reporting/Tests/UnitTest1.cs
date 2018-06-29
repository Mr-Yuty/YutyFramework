using NUnit.Framework;
using YutyFramework;

namespace reporting.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class UnitTest1 : BaseTest
    {
        [Test]
        public void TC001_SearchForABlouse()
        {
            var homePage = new AutomationPractisePage(Driver);
            homePage.GoTo();
            var searchPage = homePage.SearchFor("blouse");
            Assert.IsFalse(searchPage.Contains(Item.Blouse),"Did not find a blouse");
        }

    }
}
