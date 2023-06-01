using NLog;
using TAF_TMS_C1onl.Clients;

namespace TAF_TMS_C1onl.Tests.API
{
    internal class BaseApiTest
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected ApiClient _apiClient;

        [OneTimeSetUp]
        public void InitApiClient()
        {
            _apiClient = new ApiClient();
        }
    }
}