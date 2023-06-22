using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Pages;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Steps.GUISteps
{
    [Binding]
    internal class LoginSteps : BaseGUIStep
    {
        public LoginPage LoginPage => new(Driver);

        public LoginSteps(Browser browser) : base(browser) { }

        [Given("open login page")]
        public void OpenLoginPage()
        {
            LoginPage.OpenPageByUrl();
        }

        [Given("general user login")]
        [When("general user login")]
        public void Login()
        {
            LoginPage.Login(
                Configurator.Admin!.Username!,
                Configurator.Admin!.Password!);
        }

        [When(@"user ""([^""]*)"" with password ""([^""]*)"" log in")]
        public void TryToLogin(string username, string password)
        {
            LoginPage.TryToLogin(
                username,
                password);
        }

        [Then("the dashboard page is opened")]
        public void CheckDashboardPageTitle()
        {
            CheckTitle("All Projects - TestRail");
        }

        [Then("the login page is opened")]
        public void CheckLogindPageTitle()
        {
            CheckTitle("Login - TestRail");
        }
    }
}