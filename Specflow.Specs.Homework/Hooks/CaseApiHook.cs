using TAF_TMS_C1onl.Utilites.Helpers;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Hooks
{
    [Binding]
    internal class CaseApiHook : ApiHook
    {
        public CaseApiHook(ScenarioContext scenarioContext) :
            base(scenarioContext)
        {
            _scenarioContext.Add("New case name", null);
            _scenarioContext.Add("Recently added case", null);
            _scenarioContext.Add("Received case", null);
            _scenarioContext.Add("Updated case", null);
        }

        [BeforeScenario("Case")]
        public void BeforeCaseAPIScenario()
        {
            _scenarioContext["New case name"] = FakerHelper.Faker.Lorem.Word() + " case";
        }

        [AfterScenario("Case")]
        public void AfterCaseAPIScenario()
        {
            _scenarioContext["New case name"] = null;
            _scenarioContext["Recently added case"] = null;
            _scenarioContext["Received case"] = null;
            _scenarioContext["Updated case"] = null;
        }
    }
}