using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoard.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }
        public virtual List<JobEntity> Jobs { get; set; } = new List<JobEntity>();
        public virtual List<ApplicationEntity> UserApps { get; set; } = new List<ApplicationEntity>();
    }
}
