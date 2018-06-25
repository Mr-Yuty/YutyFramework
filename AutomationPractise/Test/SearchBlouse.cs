using NUnit.Framework;
using YutyFramework;

namespace AutomationPractise
{
    [TestFixture]
    [Category("AutomationPractice")]
    public class SearchBlouse : BaseTest
    {
        [Test]
        [Description("Search for a blouse and assert the result")]
        [Author("Yuty","Lordyuty@live.fr")]
        public void TC001_SearchForBlouse()
        {
            var automationPractisePage = new AutomationPractisePage(Driver);
            automationPractisePage.GoTo();
            var SearchResultPage = automationPractisePage.SearchFor("Blouse");
            Assert.IsTrue(SearchResultPage.Contains(Item.Blouse), "The page was not displayed or did not contain the following item : " + Item.Blouse.ToString());

        }
        [Test]
        [Description("Verify that the contact form is displayed")]
        [Author("Yuty", "Lordyuty@live.fr")]
        public void TC002_CheckContactPageIsVisible()
        {
            var automationPractisePage = new AutomationPractisePage(Driver);
            automationPractisePage.GoTo();
            var contactPage = automationPractisePage.ClickContact();
            Assert.IsTrue(contactPage.ElementsAreVisible());

        }
    }
}
