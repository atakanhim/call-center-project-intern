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

     

        public Job GetById(int id)
        {
            throw new NotImplementedException();
        }

      

        public List<Job> GetList()
        {
            return _jobDal.GetListAll();
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
