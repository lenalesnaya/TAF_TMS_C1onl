using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;

namespace TAF_TMS_C1onl.Tests;

[AllureNUnit]
[Parallelizable(ParallelScope.All)]
public class BaseTest
{
    protected IWebDriver Driver;
    protected NavigationSteps NavigationSteps;
    protected ProjectSteps ProjectSteps;
    private AllureLifecycle _allure;
    
    [SetUp]
    public void Setup()
    {
        Driver = new Browser().Driver;
        
        // Инициализация Steps
        NavigationSteps = new NavigationSteps(Driver);
        ProjectSteps = new ProjectSteps(Driver);

        // Инициализация Allure
        _allure = AllureLifecycle.Instance;
    }

    [TearDown]
    public void TearDown()
    {
        // Проверка, что тест упал
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            // Создание скриншота
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            // Прикрепление сриншота
            _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
        }
        
        Driver.Quit();
        Driver.Dispose();
    }
}