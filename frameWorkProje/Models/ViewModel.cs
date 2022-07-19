using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frameWorkProje.Models
{
    public class ViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
    }
}