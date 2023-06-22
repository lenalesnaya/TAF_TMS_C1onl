using Newtonsoft.Json;

namespace TAF_TMS_C1onl.Models
{
    public class Case
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("section_id")]
        public int SectionId { get; set; }

        [JsonProperty("template_id")]
        public int TemplateId { get; set; }

        [JsonProperty("type_id")]
        public int TypeId { get; set; }

        [JsonProperty("priority_id")]
        public int PriorityId { get; set; }

        [JsonProperty("milestone_id")]
        public int? MilestoneId { get; set; }

        [JsonProperty("refs")]
        public string? Refs { get; set; }

        [JsonProperty("created_by")]
        public int CreatedBy { get; set; }

        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }

        [JsonProperty("updated_by")]
        public int UpdatedBy { get; set; }

        [JsonProperty("updated_on")]
        public string UpdatedOn { get; set; }

        [JsonProperty("estimate")]
        public string? Estimate { get; set; }

        [JsonProperty("estimate_forecast")]
        public string EstimateForecast { get; set; }

        [JsonProperty("suite_id")]
        public int SuiteId { get; set; }

        //[JsonProperty("display_order")]
        //public int DisplayOrder { get; set; }

        //[JsonProperty("is_deleted")]
        //public int IsDeleted { get; set; }

        //[JsonProperty("custom_automation_type")]
        //public int CustomAutomationType { get; set; }

        // needed?
        //public string? AdditionalProperty { get; set; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id} // " +
            $"{nameof(Title)}: {Title} // " +
            $"{nameof(SectionId)}: {SectionId} // " +
            $"{nameof(TypeId)}: {TypeId} // " +
            $"{nameof(CreatedBy)}: {CreatedBy} // " +
            $"{nameof(CreatedOn)}: {CreatedOn} // " +
            $"{nameof(UpdatedBy)}: {UpdatedBy} // " +
            $"{nameof(UpdatedOn)}: {UpdatedOn} // " +
            $"{nameof(Estimate)}: {Estimate} // ";

        protected bool Equals(Case other) =>
                Title == other.Title &&
                SectionId == other.SectionId &&
                CreatedBy == other.CreatedBy &&
                CreatedOn == other.CreatedOn &&
                UpdatedBy == other.UpdatedBy &&
                UpdatedOn == other.UpdatedOn &&
                Estimate == other.Estimate;

        public override int GetHashCode() =>
            HashCode.Combine(
                Title,
                SectionId,
                CreatedBy,
                CreatedOn,
                UpdatedBy,
                UpdatedOn,
                Estimate);

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((Case)obj);
        }
    }
}