using NUnit.Framework;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Steps
{
    [Binding]
    public class ParametrizedSpecflowStudyingFeatureSteps
    {
        private Browser? _browser;
        private NavigationSteps? _navigationSteps;


        [Given(@"browser is opened")]
        public void OpenBrowser()
        {
            _browser = new Browser();
        }

        [Given(@"login page is opened")]
        public void OpenLoginPage()
        {
            _navigationSteps = new NavigationSteps(_browser!.Driver!);
            _navigationSteps.NavigateToLoginPage();
        }

        [When(@"user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        public void Login(string username, string password)
        {
            _navigationSteps!.SuccessfulLogin(username, password);
        }

        [Then(@"the title is ""([^""]*)""")]
        public void CheckTitle(string title)
        {
            Assert.That(title, Is.EqualTo(_browser!.Driver!.Title));
        }

        [Then(@"project Id is (.*)")]
        public void CheckProjectId(int id)
        {
            Assert.That(id, Is.EqualTo(123));
        }

        [After()]
        public void CloseBrowser()
        {
            if (_browser is not null)
                _browser!.Driver!.Quit();
        }
    }
}