namespace JobBoard.Models.Job
{
    public class JobUpdate
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public int? JobSalary { get; set; }
        public int? JobHourlyPay { get; set; }
        public string JobLocation { get; set; }
        public string JobRequirements { get; set; }
        public string JobSummary { get; set; }
        public string JobDescription { get; set; }
        public bool JobIsAvailable { get; set; }
    }
}
