using NUnit.Framework;
using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]

namespace Specflow.Specs.Homework.Hooks
{
    [Binding]
    internal class BrowserHook
    {
        private Browser _browser;

        public BrowserHook(Browser browser)
        {
            _browser = browser;
        }

        [BeforeScenario("GUI")]
        public void BeforeGUIScenario()
        {
            _browser!.Driver!.Navigate().GoToUrl(Configurator.AppSettings.URL);
        }

        [AfterScenario("GUI")]
        public void AfterGUIScenario()
        {
            _browser!.Driver!.Quit();
        }
    }
}