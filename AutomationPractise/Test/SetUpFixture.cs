using NUnit.Framework;
using YutyFramework;

namespace AutomationPractise
{
    [SetUpFixture]
    public class SetUpFixture
    {
        [OneTimeSetUp]
        public void Init()
        {
            Reporter.StartReporter();
        }
    }
}
