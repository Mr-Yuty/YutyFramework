using NUnit.Framework;
using YutyFramework;

namespace PageObjectQuizz
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
