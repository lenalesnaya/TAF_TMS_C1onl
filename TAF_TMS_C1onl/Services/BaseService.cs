using TAF_TMS_C1onl.Clients;

namespace TAF_TMS_C1onl.Services
{
    internal class BaseService
    {
        protected ApiClient _apiClient;

        public BaseService(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }
    }
}