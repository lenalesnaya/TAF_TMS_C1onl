using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;

namespace TAF_TMS_C1onl.Tests;

[Parallelizable(ParallelScope.All)]
public class BaseTest
{
    protected IWebDriver Driver;
    protected NavigationSteps NavigationSteps;
    protected ProjectSteps ProjectSteps;
    
    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        
        // Инициализация Steps
        NavigationSteps = new NavigationSteps(Driver);
        ProjectSteps = new ProjectSteps(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}