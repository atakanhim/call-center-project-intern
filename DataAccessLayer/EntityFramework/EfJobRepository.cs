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
        public void ChangeJubStatus(int jobID)
        {
            Context c = new Context();
            var job = c.Jobs.Where(x => x.JobId == jobID).FirstOrDefault();
            if(job.JobStatus=="aktif")
            {
                job.JobStatus = "deaktif";
            }
            //else if (job.JobStatus == "deaktif")
            //{
            //    job.JobStatus = "aktif";
            //}

            c.SaveChanges();
        }

        public List<Job> GetJobWithfilter(bool adminmi = false,string username="")
        {
            Context c = new Context();
            List<Job> jobValue = c.Jobs.ToList();
            if (adminmi==false)
            {        
                jobValue = (from job in c.Jobs
                            join us in c.Users
                                on job.UserId equals us.UserId
                            join call in c.CallLogs
                              on job.CallLogId equals call.CallLogId
                            join cust in c.Customers
                              on call.CustomerId equals cust.CustomerId
                            where (us.UserName == username && job.JobStatus=="aktif")
                            select job
                            ).ToList();
            } 
            return jobValue;     
        }


    }
}
