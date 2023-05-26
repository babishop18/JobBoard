using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobBoard.Data.Entities
{
    public class ResponseEntity
    {
        [Key]
        public int ResponseId { get; set; }
        public enum ResponseStatus { Accepted, Denied, ContinueProcess }
        public string AppResponseMessage { get; set; }
        public DateTimeOffset DateResponded { get; set; }
        [ForeignKey(nameof(Application))]
        public int AppFKey { get; set; }
        public virtual ApplicationEntity Application { get; set; }
    }
}
