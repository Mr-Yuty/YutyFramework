using NUnit.Framework;
using YutyFramework;

namespace reporting
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
