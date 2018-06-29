using DataObjectLibrairies;
using NUnit.Framework;
using YutyFramework;

namespace SampleApplication
{
    [TestFixture]
    [Parallelizable]
    public class ParalelAttempt1 : BaseTest
    {
        public TestUser TheTestUser { get; private set; }
        public TestUser TheOtherTestUser { get; private set; }
        public SampleApplicationPage SampleApplicationPage { get; private set; }

        [SetUp]
        public void TestInit()
        {
            TheTestUser = new TestUser(Personat.YoungGuy);
            TheOtherTestUser = new TestUser(Personat.SJW);
            SampleApplicationPage = new SampleApplicationPage(Driver);
        }

        [Test]
        [Category("batch 1")]
        public void ParallelAttempt1()
        {
            SampleApplicationPage.GoTo();
            SampleApplicationPage.FillOutEmergencyForm(TheOtherTestUser);
            var ultimateQAHomePage = SampleApplicationPage.FillOutFormAndSubmit(TheTestUser);
            AssertIsVisible(ultimateQAHomePage);
        }
        private static void AssertIsVisible(UltimateQAHomePage ultimateQAHomePage)
        {
            Assert.IsTrue(ultimateQAHomePage.IsVisible, "Ultimate QA Page was not visible");
        }
    }
}
