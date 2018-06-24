using NUnit.Framework;
using YutyFramework;

namespace AutomationPractise
{
    [TestFixture]
    public class SearchBlouse : BaseTest
    {
        [Test]
        public void SearchForABlouse()
        {
            var automationPractisePage = new AutomationPractisePage(Driver);
            automationPractisePage.GoTo();
            var SearchResultPage = automationPractisePage.SearchFor(Item.Blouse.ToString());
            Assert.IsTrue(SearchResultPage.Contains(Item.Blouse), "The page was not displayed or did not contain the following item : " + Item.Blouse.ToString());

        }
    }
}
