namespace JobNotesAPI.Models
{
    public class JobInfo
    {
        public Guid Id { get; set; }
        public required string CompanyName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Details { get; set; }
        public bool Searched { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? SearchedDate { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime? RemovedDate { get; set; }
    }
}
