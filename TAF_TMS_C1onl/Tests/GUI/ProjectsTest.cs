using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests;

public class ProjectsTest : BaseTest
{
    [Test]
    [Regression]
    public void CreateProjectTest()
    {
        var testProject = TestDataHelper.GetTestEntity<Project>("GeneralProject");
        
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        ProjectSteps.NavigateToAddProjectPage();
    }
}