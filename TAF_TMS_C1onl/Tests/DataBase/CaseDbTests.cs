using TAF_TMS_C1onl.Core;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services.API;
using TAF_TMS_C1onl.Tests.API;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.DataBase
{
    internal class CaseDbTests : BaseApiTest
    {
        private CaseService _caseService;

        [OneTimeSetUp]
        public void InitService()
        {
            _caseService = new CaseService(_apiClient);
        }

        [Test]
        public void AddCase()
        {
            var addedCase = HandleCaseAdding(out string randomCaseTitle);

            Assert.Multiple(() =>
            {
                Assert.That(addedCase!.Title, Is.EqualTo(randomCaseTitle));
            });
        }

        [Test]
        public void GetCase()
        {
            var addedCase = HandleCaseAdding(out string randomCaseTitle);

            var receivedCase = _caseService.GetCase<Case>(addedCase!.Id);
            _logger.Info("Received object! " + receivedCase);

            Assert.Multiple(() =>
            {
                Assert.That(receivedCase.Title, Is.EqualTo(randomCaseTitle));
            });
        }

        [Test]
        public void UpdateCase()
        {
            var addedCase = HandleCaseAdding(out _);
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
            var addedCase = HandleCaseAdding(out _);

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

        private Case? HandleCaseAdding(out string randomCaseTitle)
        {
            using (var dbConnector = new EFDBConnector())
            {
                var cases = dbConnector.Cases!.ToList();
                var randomCase = cases[new Random().Next(cases.Count)];
                randomCaseTitle = randomCase.Title;

                var addedCase = _caseService.AddCase<Case>(randomCase.SectionId, randomCase);
                _logger.Info("New object! " + addedCase);

                return addedCase;
            }
        }
    }
}