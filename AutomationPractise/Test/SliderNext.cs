using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YutyFramework;

namespace AutomationPractise
{
    [TestFixture]
    [Category("AutomationPractice")]
    public class SliderNext : BaseTest
    {
        [Test]
        [Description("Search for a blouse and assert the result")]
        [Author("Yuty", "Lordyuty@live.fr")]
        public void TC003_SliderClickNext()
        {
            var automationPractisePage = new AutomationPractisePage(Driver);
            automationPractisePage.GoTo();
            var currentImage = automationPractisePage.Slider.GetCurrentImage();
            automationPractisePage.Slider.ClickNext();
            var nextImage = automationPractisePage.Slider.GetCurrentImage();
            Assert.AreNotEqual(nextImage,currentImage);
        }
    }
}
