using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CustomerDate { get; set; }

        public ICollection<CallLog> CallLogs { get; set; }
    }
}
