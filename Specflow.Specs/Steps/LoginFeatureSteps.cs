using TAF_TMS_C1onl.Core;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Steps
{
    [Binding]
    internal class LoginFeatureSteps : BaseFeatureSteps
    {
        public LoginFeatureSteps(Browser browser) : base(browser)
        {
        }

        [Given(@"new browser is opened")]
        public void OpenNewBrowser()
        {
            // already done
        }

        [Given(@"a login page is displayed")]
        public void OpenALoginPage()
        {
            navigationSteps.NavigateToLoginPage();
        }

        [Given(@"the user ""([^""]*)"" with password ""([^""]*)"" logged in")]
        public void Login(string username, string password)
        {
            navigationSteps.SuccessfulLogin(username, password);
        }
    }
}