using Newtonsoft.Json.Linq;
using RestSharp;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Services;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Tests.API
{
    internal class ProjectTests : BaseApiTest
    {
        private ProjectService _projectService;

        [OneTimeSetUp]
        public void InitService()
        {
            _projectService = new ProjectService(_apiClient);
        }

        [Test]
        public void GetProjectTest_1()
        {
            var request = new RestRequest(ProjectService.GetProjectEndpoint)
                .AddUrlSegment("project_id", "1");
            var response = _apiClient.Execute(request);
            _logger.Info(response.Content!.Normalize);

            var json = response.Content;
            // выполним десериализацию json-строки в объект JObject
            //var jsonObject1 = JObject.Parse(json);
            var jsonObject = JsonHelper.FromJson(json);

            // использование JsonPath для извлечения значения из объекта (можно использовать сервис)
            var value = jsonObject.SelectToken("$.name");
            _logger.Info("jsonObject -> name: " + value);
        }

        [Test]
        public void GetProjectTest_2()
        {
            var json = _projectService.GetProject("1").Content;

            // Выполним десериализацию JSON-строки в объект JObject
            var jsonObject1 = JObject.Parse(json);
            var jsonObject2 = JsonHelper.FromJson(json);

            // Использование JsonPath для извлечения занчения из объекта
            var value = jsonObject1.SelectToken("$.name");
            _logger.Info("jsonObject1 -> name: " + value);

            var value2 = jsonObject2.SelectToken("$.name");
            _logger.Info("jsonObject2 -> name: " + value);
        }

        [Test]
        public void GetProjectTest_3()
        {
            var actualProject = _projectService.GetProject<Project>(1);
            _logger.Info("jsonObject -> name: " + actualProject.Name);
        }

        [Test]
        public void GetProjectTest_1Async()
        {
            var request = new RestRequest(ProjectService.GetProjectEndpoint)
                .AddUrlSegment("project_id", "1");
            var response = _apiClient.ExecuteAsync(request);
            _logger.Info(response.Result.Content!.Normalize);

            var json = response.Result.Content;

            // выполним десериализацию json-строки в объект JObject
            //var jsonObject1 = JObject.Parse(json);
            var jsonObject = JsonHelper.FromJson(json);

            // использование json path для извлечения значения из объекта
            var value = jsonObject.SelectToken("$.name");
            _logger.Info("jsonObject -> name: " + value);
        }

        [Test]
        public void GetProjectTest_3Async()
        {
            var actualProject = _projectService.GetProjectAsync<Project>(1);
            _logger.Info("jsonObject -> name: " + actualProject.Name);
        }

        // whyyyyy???
        [Test]
        public void AddProjectTest_1Async()
        {
            var expectedProject = new Project()
            {
                Name = "Good Project",
                Announcement = "Just good."
                //ShowAnnouncement = true,
                //SuiteMode = 1
            };

            var actualProject = _projectService.AddProjectAsync<Project>(expectedProject);
            _logger.Info("New object! " + actualProject);

            Assert.Multiple(() =>
            {
                Assert.That(actualProject.Name, Is.EqualTo(expectedProject.Name));
                Assert.That(actualProject.Announcement, Is.EqualTo(expectedProject.Announcement));
                //Assert.That(actualProject.ShowAnnouncement, Is.EqualTo(expectedProject.ShowAnnouncement));
                //Assert.That(actualProject.SuiteMode, Is.EqualTo(expectedProject.SuiteMode));
            });

            //Assert.That(actualProject, Is.EqualTo(expectedProject));
        }

        [Test]
        public void GetProjectsTest_1()
        {
            var response = _projectService.GetProjects();
            _logger.Info(response.Content);
        }
    }
}