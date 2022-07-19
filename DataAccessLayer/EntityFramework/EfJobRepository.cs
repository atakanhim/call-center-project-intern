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
            List<Job> jobValue = new List<Job>();
            if (ad != null && numara != null & abc != null)//hepsi dolu ise
            {
               return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (cust.CustomerName.Contains(ad) && call.CallLogId == numara)
                            orderby cust.CustomerName
                            select job
                                 ).ToList();
            }
            else if (ad != null && numara != null && abc == null)// sıralama yok sadece numara ve 
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (cust.CustomerName.Contains(ad) && call.CallLogId == numara)
                            select job
                                ).ToList();

            }
            else if (ad == null && numara != null && abc != null)//
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (call.CallLogId == numara)
                            orderby cust.CustomerName
                            select job
                                ).ToList();

            }
            else if (ad != null && numara == null && abc != null)
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (cust.CustomerName.Contains(ad))
                            orderby cust.CustomerName
                            select job
                          ).ToList();
            }

            else if (ad == null && numara == null && abc != null)
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            orderby cust.CustomerName
                            select job
                          ).ToList();
            }
            else if (ad != null && numara == null && abc == null)
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (cust.CustomerName.Contains(ad))
                            select job
                          ).ToList();
            }
            else if (ad == null && numara != null && abc == null)
            {
                return jobValue = (from job in c.Jobs
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (call.CallLogId == numara)
                            select job
                          ).ToList();
            }

            else
            {
                return jobValue;
            }
        }



    }
}
