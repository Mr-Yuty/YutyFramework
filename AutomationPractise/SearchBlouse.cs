using NUnit.Framework;
using YutyFramework;

namespace AutomationPractise
{
    [TestFixture]
    [Category("SearchResults")]
    public class SearchBlouse : BaseTest
    {
        [Test]
        [Description("Search for a blouse and assert the result")]
        [Author("Yuty","Lordyuty@live.fr")]
        public void TC001_SearchForBlouse()
        {
            var automationPractisePage = new AutomationPractisePage(Driver);
            automationPractisePage.GoTo();
            var SearchResultPage = automationPractisePage.SearchFor(Item.Blouse.ToString());
            Assert.IsTrue(SearchResultPage.Contains(Item.Blouse), "The page was not displayed or did not contain the following item : " + Item.Blouse.ToString());

        }
    }
}
