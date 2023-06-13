using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Utilites.Configuration;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Hooks
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

        [BeforeScenario("GeneralUser")]
        public void BeforGeneralUserScenario()
        {
            Console.Out.WriteLine("GeneralUser");
        }

        [AfterScenario("GUI")]
        public void AfterScenario()
        {
            _browser!.Driver!.Quit();
        }
    }
}