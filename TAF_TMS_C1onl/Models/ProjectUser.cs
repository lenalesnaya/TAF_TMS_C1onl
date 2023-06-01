using Newtonsoft.Json;

namespace TAF_TMS_C1onl.Models
{
    public class ProjectUser
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("global_role_id")]
        public int? GlobalRoleId { get; set; }

        [JsonProperty("global_role")]
        public string? GlobalRole { get; set; }

        [JsonProperty("project_role_id")]
        public int? ProjectRoleId { get; set; }

        [JsonProperty("project_role")]
        public string? ProjectRole { get; set; }
    }
}