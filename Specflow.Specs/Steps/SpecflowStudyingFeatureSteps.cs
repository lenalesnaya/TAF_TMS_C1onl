using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Steps
{
    [Binding]
    public class SpecflowStudyingFeatureSteps
    {
        [Given(@"Browser is opened :P")]
        public void OpenBrowser()
        {

        }

        [Given(@"Login page is opened ;P")]
        [When(@"Login page is opened ;P")]
        public void OpenLoginPage()
        {

        }

        [Then(@"Username fieled is displayed")]
        public void IsUsernameFieldDisplayed()
        {
            Assert.That(true);
        }

        [Then(@"Password fieled is displayed")]
        public void IsPasswordFieldDisplayed()
        {
            Assert.That(true);
        }

        [Then(@"Error isn`t displayed")]
        public void IsErrorNotDisplayed()
        {
            Assert.That(true);
        }
    }
}