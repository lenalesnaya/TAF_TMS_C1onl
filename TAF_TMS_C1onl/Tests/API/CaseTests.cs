using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.API;
using TAF_TMS_C1onl.TestData.DynamicTestData;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    internal class CaseTests : BaseApiTest
    {
        private CaseService _caseService;

        [OneTimeSetUp]
        public void InitService()
        {
            _caseService = new CaseService(_apiClient);
        }

        [Test]
        //[TestCaseSource(typeof(CaseTitleRandomData), nameof(CaseTitleRandomData.TestCases))]
        public void AddCase(/*string caseTitle*/)
        {
            var randomCaseTitle = FakerHelper.Faker.Lorem.Word() + " case";
            var addedCase = HandleCaseAdding(randomCaseTitle);

            Assert.Multiple(() =>
            {
                Assert.That(addedCase!.Title, Is.EqualTo(randomCaseTitle));
            });
        }

        [Test]
        public void GetCase()
        {
            var addedCase = HandleCaseAdding(TestDataHelper.GetTestEntity<Case>("GeneralCase").Title);

            var receivedCase = _caseService.GetCase<Case>(addedCase!.Id);
            _logger.Info("Received object! " + receivedCase);

            Assert.Multiple(() =>
            {
                Assert.That(receivedCase.Title, Is.EqualTo(addedCase.Title));
            });
        }

        [Test]
        //[TestCaseSource(typeof(CaseTitleRandomData), nameof(CaseTitleRandomData.TestCases))]
        public void UpdateCase(/*string caseNewTitle*/)
        {
            var addedCase = HandleCaseAdding(TestDataHelper.GetTestEntity<Case>("GeneralCase").Title);
            var newCase = new Case
            {
                Title = FakerHelper.Faker.Lorem.Word() + " case"
        };

            var receivedCase = _caseService.UpdateCase<Case>(addedCase!.Id, newCase);
            _logger.Info("Updated object! " + receivedCase);

            Assert.Multiple(() =>
            {
                Assert.That(receivedCase.Id, Is.EqualTo(addedCase.Id));
                Assert.That(receivedCase.Title, Is.EqualTo(newCase.Title));
            });
        }

        [Test]
        public void DeleteCase()
        {
            var addedCase = HandleCaseAdding(TestDataHelper.GetTestEntity<Case>("GeneralCase").Title);

            _caseService.DeleteCase(addedCase!.Id);
            try
            {
                _caseService.GetCase(addedCase.Id);
            }
            catch (HttpRequestException ex)
            {
                _logger.Info(ex.Message);
                Assert.That(true);
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
                Assert.That(false);
            }
        }

        private Case? HandleCaseAdding(string title)
        {
            var expectedCase = new Case()
            {
                Title = title,
            };

            var addedCase = _caseService.AddCase<Case>(TestDataHelper.GetTestEntity<Case>("GeneralCase").SectionId, expectedCase);
            _logger.Info("New object! " + addedCase);

            return addedCase;
        }
    }
}