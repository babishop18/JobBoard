using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.Entities
{
    public class ApplicationEntity
    {
        [Key]
        public int AppId { get; set; }
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string DesiredPay { get; set; }
        public bool HasResponse { get; set; }
        public DateTimeOffset DateSubmitted { get; set; }
        [ForeignKey(nameof(Applicant))]
        public string ApplicantFKey { get; set; }
        public virtual ApplicationUser Applicant { get; set; }
        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public virtual JobEntity Job { get; set; }
        public virtual ResponseEntity Response { get; set; }
    }
}
