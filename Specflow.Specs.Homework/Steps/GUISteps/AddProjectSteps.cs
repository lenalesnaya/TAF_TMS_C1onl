using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Pages;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Steps.GUISteps
{
    [Binding]
    internal class AddProjectSteps : BaseGUIStep
    {
        public DashboardPage DashboardPage => new(Driver);
        public AddProjectPage AddProjectPage => new(Driver);

        public AddProjectSteps(Browser browser) : base(browser) { }

        [Given("open project adding page")]
        public void OpenAddProjectPage()
        {
            DashboardPage.AddProjectSidebarButton.Click();
        }

        [When(@"add ""([^""]*)"" project")]
        public void AddProject(string projectName)
        {
            AddProjectPage.AddProject(projectName);
        }

        [Then("the projects page is opened")]
        public void CheckProjectsPageTitle()
        {
            CheckTitle("Projects - TestRail");
        }
    }
}