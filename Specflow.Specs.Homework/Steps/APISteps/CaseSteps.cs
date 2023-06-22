using NUnit.Framework;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TAF_TMS_C1onl.Utilites.Helpers;
using TechTalk.SpecFlow;

namespace Specflow.Specs.Homework.Steps.APISteps
{
    [Binding]
    internal class CaseSteps : BaseAPIStep
    {
        private CaseService _caseService;

        public CaseSteps(ApiClient apiClient, ScenarioContext scenarioContext) :
            base(apiClient, scenarioContext)
        {
            _caseService = new CaseService(apiClient);
        }

        [Given("add case")]
        [When("add case")]
        public void AddCase()
        {
            var newCase = new Case()
            {
                Title = _scenarioContext.Get<string>("New case name")
            };

            var addedCase = _caseService.AddCase<Case>(
                TestDataHelper.GetTestEntity<Case>("GeneralCase").SectionId, newCase);
            _scenarioContext["Recently added case"] = addedCase;
        }

        [When("get case")]
        public void GetCase()
        {
            _scenarioContext["Received case"] =
                _caseService.GetCase<Case>(_scenarioContext.Get<Case>("Recently added case").Id);
        }

        [When("update case")]
        public void UpdateCase()
        {
            _scenarioContext["New case name"] = FakerHelper.Faker.Lorem.Word() + " case";

            var newCase = new Case()
            {
                Title = _scenarioContext.Get<string>("New case name")
            };

            _scenarioContext["Updated case"] = _caseService.UpdateCase<Case>(
                _scenarioContext.Get<Case>("Recently added case").Id, newCase);
        }

        [When("delete case")]
        public void DeleteCase()
        {
            _caseService.DeleteCase(_scenarioContext.Get<Case>("Recently added case").Id);
        }

        [Then("case is added")]
        public void CheckCaseIsAdded()
        {
            Assert.That(_scenarioContext.Get<Case>("Recently added case").Title,
                Is.EqualTo(_scenarioContext.Get<string>("New case name")));
        }

        [Then("case received")]
        public void CheckCaseReceived()
        {
            Assert.That(_scenarioContext.Get<Case>("Received case").Title,
                Is.EqualTo(_scenarioContext.Get<Case>("Recently added case").Title));
        }

        [Then("case updated")]
        public void CheckCaseUpdated()
        {
            Assert.Multiple(() =>
            {
                Assert.That(_scenarioContext.Get<Case>("Updated case").Id,
                    Is.EqualTo(_scenarioContext.Get<Case>("Recently added case").Id));
                Assert.That(_scenarioContext.Get<Case>("Updated case").Title,
                    Is.EqualTo(_scenarioContext.Get<string>("New case name")));
            });
        }

        [Then("case deleted")]
        public void CheckCaseDeleted()
        {
            try
            {
                _caseService.GetCase(_scenarioContext.Get<Case>("Recently added case").Id);
                Assert.That(false);
            }
            catch (HttpRequestException ex)
            {
                Console.Out.WriteLine(ex.Message);
                Assert.That(true);
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                Assert.That(false);
            }
        }
    }
}