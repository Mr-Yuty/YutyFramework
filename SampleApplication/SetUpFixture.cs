using NUnit.Framework;
using YutyFramework;

namespace SampleApplication
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
