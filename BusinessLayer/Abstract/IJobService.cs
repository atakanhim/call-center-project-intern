using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IJobService
    {
        void JobAdd(Job job);
        void JobDelete(Job job);
        void JobUpdate(Job job);
        List<Job> GetList();
        List<Job> GetList(Expression<Func<Job, bool>> filter);

        void ChangeJubStatus(int jobID);
        Job GetById(int id);
        Job GetByFilter(Expression<Func<Job, bool>> filter);

        List<Job> GetJobWithfilter(bool adminmi=false, string username  = "");
    }
}
