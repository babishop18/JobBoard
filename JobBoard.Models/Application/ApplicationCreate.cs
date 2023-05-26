using System.ComponentModel.DataAnnotations.Schema;

namespace JobBoard.Models.Application
{
    public class ApplicationCreate
    {
        [ForeignKey("Job")]
        public int JobId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string DesiredPay { get; set; }
    }
}
