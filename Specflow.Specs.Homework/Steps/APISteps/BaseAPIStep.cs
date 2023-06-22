using TAF_TMS_C1onl.Clients;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Steps.APISteps
{
    internal class BaseAPIStep
    {
        protected ApiClient _apiClient;
        protected ScenarioContext _scenarioContext;

        public BaseAPIStep(ApiClient apiClient, ScenarioContext scenarioContext)
        {
            _apiClient = apiClient;
            _scenarioContext = scenarioContext;
        }
    }
}