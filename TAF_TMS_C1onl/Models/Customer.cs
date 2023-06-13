namespace TAF_TMS_C1onl.Models
{
    public record Customer
    {
        public int Id { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int Age { get; set; }
    }
}