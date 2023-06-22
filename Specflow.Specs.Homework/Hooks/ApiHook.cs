using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Hooks
{
    [Binding]
    internal class ApiHook
    {
        protected ScenarioContext _scenarioContext;

        public ApiHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}