using OpenQA.Selenium;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Steps;

namespace Specflow.Specs.Steps
{
    internal class BaseFeatureSteps
    {
        protected IWebDriver driver;
        protected NavigationSteps navigationSteps;

        public BaseFeatureSteps(Browser browser)
        {
            driver = browser!.Driver!;
            navigationSteps = new NavigationSteps(driver);
        }
    }
}