using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string JobDescription { get; set; }
        public string JobMethods { get; set; }
        public bool IsImportant { get; set; }
        public string JobStatus { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime UpdatingTime { get; set; }

        public int CallLogId { get; set; }
        public CallLog CallLog { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
