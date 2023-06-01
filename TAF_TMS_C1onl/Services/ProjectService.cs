using RestSharp;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services
{
    // can we name a method as Async, if it doesn`t have async keyword?
    // should we pass async up the method call tree?
    internal class ProjectService : BaseService
    {
        public const string GetProjectEndpoint = "index.php?/api/v2/get_project/{project_id}";
        public const string GetProjectsEndpoint = "index.php?/api/v2/get_projects";
        public const string AddProjectEndpoint = "index.php?/api/v2/add_project";

        public ProjectService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse GetProject(string projectId)
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute(request);
        }

        public ProjectType GetProject<ProjectType>(string projectId)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.Execute<ProjectType>(request);
        }

        public RestResponse GetProjectAsync(string projectId)
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.ExecuteAsync(request).Result;
        }

        public ProjectType GetProjectAsync<ProjectType>(string projectId)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(GetProjectEndpoint)
                .AddUrlSegment("project_id", projectId);

            return _apiClient.ExecuteAsync<ProjectType>(request).Result;
        }

        public RestResponse GetProjects()
        {
            var request = new RestRequest(GetProjectsEndpoint);
            return _apiClient.Execute(request);
        }

        //public List<ProjectType> GetProjects<ProjectType>()
        //{
        //    var request = new RestRequest(GetProjectsEndpoint);
        //    var response = _apiClient.Execute(request);
        //    var projectsListJson = JsonHelper.FromJson(response.Content!).SelectToken("$.projects");

        //    JsonConvert......
        //}

        public RestResponse AddProject(Project project)
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(project);

            return _apiClient.Execute(request);
        }

        public RestResponse AddProjectAsync(Project project)
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(project);

            return _apiClient.ExecuteAsync(request).Result;
        }

        public ProjectType AddProject<ProjectType>(ProjectType project)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(project);

            return _apiClient.Execute<ProjectType>(request);
        }

        public ProjectType AddProjectAsync<ProjectType>(ProjectType project)
            where ProjectType : Project, new()
        {
            var request = new RestRequest(AddProjectEndpoint, Method.Post)
                .AddBody(project);

            return _apiClient.ExecuteAsync<ProjectType>(request).Result;
        }

        public RestResponse UpdateProject(string projectId, Project project)
        {
            return null;
        }

        public RestResponse DeleteProject(string projectId)
        {
            return null;
        }
    }
}