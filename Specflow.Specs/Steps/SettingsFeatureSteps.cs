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
            driver.Navigate().GoToUrl(TAF_TMS_C1onl.Utilites.Configuration.Configurator.AppSettings.URL + "index.php?/admin/site_settings");
            Assert.That(driver.Title, Is.EqualTo("Site Settings - TestRail"));
        }
    }
}