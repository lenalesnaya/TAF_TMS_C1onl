using Newtonsoft.Json;

namespace TAF_TMS_C1onl.Models
{
    public class Group
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("role")]
        public int Role { get; set; }

        [JsonProperty("role_id")]
        public int RoleId { get; set; }
    }
}