using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void ChangeJubStatus(int jobID)
        {
            _jobDal.ChangeJubStatus(jobID);
        }

        public Job GetByFilter(Expression<Func<Job, bool>> filter)
        {
            return _jobDal.GetEntityWithFilter(filter);
        }





        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

      
        public List<Job> GetJobWithfilter(string ad="", int? numara = null, string abc = "", bool adminmi=false, int userId = 0)
        {
            var value = _jobDal.GetJobWithfilter(ad, numara, abc,adminmi,userId);
            return (value);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetListAll();
        }

        public List<Job> GetList(Expression<Func<Job, bool>> filter)
        {
            return _jobDal.GetListAll(filter);
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
