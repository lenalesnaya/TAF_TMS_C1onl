using Newtonsoft.Json;

namespace TAF_TMS_C1onl.Models
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("announcement")]
        public string Announcement { get; set; }

        [JsonProperty("show_announcement")]
        public bool ShowAnnouncement { get; set; }

        [JsonProperty("is_completed")]
        public bool IsCompleted { get; set; }

        [JsonProperty("completed_on")]
        public int? CompletedOn { get; set; }

        [JsonProperty("suite_mode")]
        public int SuiteMode { get; set; }

        [JsonProperty("default_role_id")]
        public int? DefaultRoleId { get; set; }

        //[JsonProperty("default_role")]
        //public string DefaultRole { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("users")]
        public List<ProjectUser> Users { get; set; }

        [JsonProperty("groups")]
        public List<Group> Groups { get; set; }

        //public string? AdditionalProperty { get; set; }

        public override string ToString() => 
            $"{nameof(Id)}: {Id} // " +
            $"{nameof(Announcement)}: {Announcement} // " +
            $"{nameof(CompletedOn)}: {CompletedOn} // " +
            //$"{nameof(DefaultRole)}: {DefaultRole} // " +
            $"{nameof(DefaultRoleId)}: {DefaultRoleId} // " +
            $"{nameof(IsCompleted)}: {IsCompleted} // " +
            $"{nameof(Name)}: {Name} // " +
            $"{nameof(ShowAnnouncement)}: {ShowAnnouncement} // " +
            $"{nameof(SuiteMode)}: {SuiteMode} // " +
            $"{nameof(Url)}: {Url} // ";

        protected bool Equals(Project other) =>
                Announcement == other.Announcement &&
                CompletedOn == other.CompletedOn &&
                //DefaultRole == other.DefaultRole &&
                DefaultRoleId == other.DefaultRoleId &&
                IsCompleted == other.IsCompleted &&
                ShowAnnouncement == other.ShowAnnouncement &&
                Name == other.Name &&
                SuiteMode == other.SuiteMode &&
                Url == other.Url;
                //Users == other.Users &&
                //Groups == other.Groups;

        public override int GetHashCode() =>
            HashCode.Combine(
                HashCode.Combine(Announcement, CompletedOn, /*DefaultRole,*/ DefaultRoleId),
                IsCompleted,
                ShowAnnouncement,
                Name,
                SuiteMode,
                Url,
                Users,
                Groups);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Project) obj);
        }
    }
}