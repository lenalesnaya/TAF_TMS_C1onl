using RestSharp;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;

namespace TAF_TMS_C1onl.Services
{
    public class CaseService : BaseService
    {
        public const string GetCaseEndpoint = "index.php?/api/v2/get_case/{case_id}";
        public const string AddCaseEndpoint = "index.php?/api/v2/add_case/{section_id}";
        public const string UpdateCaseEndpoint = "index.php?/api/v2/update_case/{case_id}";
        public const string DeleteCaseEndpoint = "index.php?/api/v2/delete_case/{case_id}";


        public CaseService(ApiClient apiClient) : base(apiClient) { }

        public RestResponse GetCase(int caseId)
        {
            var request = new RestRequest(GetCaseEndpoint)
                .AddUrlSegment("case_id", caseId);

            return _apiClient.Execute(request);
        }

        public CaseType GetCase<CaseType>(int caseId)
            where CaseType : Case, new()
        {
            var request = new RestRequest(GetCaseEndpoint)
                .AddUrlSegment("case_id", caseId);

            return _apiClient.Execute<CaseType>(request);
        }

        public RestResponse AddCase(int sectionId, Case newCase)
        {
            var request = new RestRequest(AddCaseEndpoint, Method.Post)
                .AddUrlSegment("section_id", sectionId)
                .AddBody(newCase);

            return _apiClient.Execute(request);
        }

        public CaseType AddCase<CaseType>(int sectionId, CaseType newCase)
            where CaseType : Case, new()
        {
            var request = new RestRequest(AddCaseEndpoint, Method.Post)
                .AddUrlSegment("section_id", sectionId)
                .AddBody(newCase);

            return _apiClient.Execute<CaseType>(request);
        }

        public RestResponse UpdateCase(int caseId, Case updatedCase)
        {
            var request = new RestRequest(UpdateCaseEndpoint, Method.Post)
                .AddUrlSegment("case_id", caseId)
                .AddBody(updatedCase);

            return _apiClient.Execute(request);
        }

        public CaseType UpdateCase<CaseType>(int caseId, Case updatedCase)
            where CaseType : Case, new()
        {
            var request = new RestRequest(UpdateCaseEndpoint, Method.Post)
                .AddUrlSegment("case_id", caseId)
                .AddBody(updatedCase);

            return _apiClient.Execute<CaseType>(request);
        }

        public RestResponse DeleteCase(int caseId)
        {
            var request = new RestRequest(DeleteCaseEndpoint, Method.Post)
                .AddUrlSegment("case_id", caseId)
                .AddBody("");

            return _apiClient.Execute(request);
        }
    }
}