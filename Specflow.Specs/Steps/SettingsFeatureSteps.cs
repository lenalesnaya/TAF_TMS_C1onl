using NUnit.Framework;
using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Steps
{
    [Binding]
    internal class SettingsFeatureSteps : BaseFeatureSteps
    {
        public SettingsFeatureSteps(Browser browser) : base(browser)
        {
        }

        [Then(@"settings page is opened")]
        public void IsSettingsPageOpened()
        {
            //driver.Navigate().GoToUrl("");
            //Assert.That(driver.Title, Is.EqualTo("Site Settings - Test Rail"));
        }
    }
}