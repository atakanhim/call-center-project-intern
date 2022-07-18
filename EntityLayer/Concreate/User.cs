using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public long UserPhone { get; set; }
        public string UserMail { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string UserPosition { get; set; }
        public DateTime UserDate { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
