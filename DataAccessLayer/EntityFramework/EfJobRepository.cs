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
        Context c = new Context();
        DbSet<Job> _object;
        public List<Job> GetJobWithfilter(string ad, int? numara = null, string abc = "")
        {
            throw new NotImplementedException();
        }

        public List<Job> GetJobWithUser()
        {
            return _object.Include(x=>x.CallLog.Customer).ToList();
        }
    }
}
