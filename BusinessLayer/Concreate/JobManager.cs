using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class JobManager : IJobService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public List<Job> GetJobWithfilter(string ad, int? numara = null, string abc = "")
        {
            var value = _jobDal.GetJobWithfilter(ad, numara,abc);
            return (value);
        }

        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetJobListWithUser()
        {
            return _jobDal.GetJobWithUser();
        }

        public List<Job> GetList()
        {
            throw new NotImplementedException();
        }

        public void JobAdd(Job job)
        {
            _jobDal.Insert(job);
        }


        public void JobDelete(Job job)
        {
            throw new NotImplementedException();
        }

       

        public void JobUpdate(Job job)
        {
            throw new NotImplementedException();
        }

      

     

      
    }
}
