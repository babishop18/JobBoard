using JobBoard.Data.Entities;

namespace JobBoard.Models.Job
{
    public class JobDetail
    {
        public string JobTitle { get; set; }
        public int? JobSalary { get; set; }
        public int? JobHourlyPay { get; set; }
        public string JobLocation { get; set; }
        public string JobRequirements { get; set; }
        public string JobSummary { get; set; }
        public string? JobDescription { get; set; }
        public bool JobIsAvailable { get; set; }
        public DateTimeOffset DateJobPosted { get; set; }
        public virtual List<ApplicationEntity> JobApps { get; set; } = new List<ApplicationEntity>();

    }
}
