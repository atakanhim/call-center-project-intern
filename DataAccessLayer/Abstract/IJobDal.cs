using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IJobDal : IGenericDal<Job>
    {
        List<Job> GetJobWithfilter(string ad="", int? numara = null, string abc = "",bool adminmi=false, int userId = 0);
        void ChangeJubStatus(int jobID);
    }
}
