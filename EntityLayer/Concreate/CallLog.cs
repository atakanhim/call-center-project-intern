using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class CallLog
    {
        [Key]
        public int CallLogId { get; set; }
        public string CallLogDesc { get; set; }
        public bool CallLogStatus { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime UpdatingTime { get; set; }
        public long  CalllNumber { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
