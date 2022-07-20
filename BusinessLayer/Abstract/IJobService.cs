using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
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

        Job GetById(int id);

        List<Job> GetJobWithfilter(string ad="", int? numara = null, string abc = "", bool adminmi=false, int userId = 0);
    }
}
