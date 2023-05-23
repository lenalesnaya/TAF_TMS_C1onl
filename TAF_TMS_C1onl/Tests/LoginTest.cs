using TAF_TMS_C1onl.Utilites.Configuration;

namespace TAF_TMS_C1onl.Tests;

public class LoginTest : BaseTest
{
    [Test]
    [SmokeTest]
    public void SuccessLoginTest()
    {
        NavigationSteps.NavigateToLoginPage();
        NavigationSteps.SuccessfulLogin(Configurator.Admin);
        
        Assert.IsTrue(NavigationSteps.DashboardPage.IsPageOpened());
    }
}