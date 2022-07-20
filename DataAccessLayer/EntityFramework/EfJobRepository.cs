using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfJobRepository : GenericRepository<Job>, IJobDal
    {
        public List<Job> GetJobWithfilter(string ad = "", int? numara = null, string abc = "")
        {


            Context c = new Context();
            List<Job> jobValue = c.Jobs.ToList();

            
            if (ad != "")
            {
                jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (cust.CustomerName.Contains(ad))
                            select job
                                ).ToList();
            }
            if (numara != null)
            {
                jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (call.CallLogId == numara)
                            select job
                              ).ToList();
            }
            if (abc == "ASC")
            {
                jobValue = jobValue.OrderBy(o => o.CallLogId).ToList();
            }

            if (abc == "DESC")
            {
                jobValue = jobValue.OrderByDescending(o => o.CallLogId).ToList();
            }

            return jobValue;


           
        }



    }
}
