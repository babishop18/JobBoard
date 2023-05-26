namespace JobBoard.Models.Job
{
    public class JobListItem
    {
        public string JobTitle { get; set; }
        public int JobId { get; set; }
        public int? JobSalary { get; set; }
        public int? JobHourlyPay { get; set; }
        public string JobLocation { get; set; }
        public string JobSummary { get; set; }
        public DateTimeOffset DateJobPosted { get; set; }
    }
}
