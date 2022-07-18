using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCallLogRepository : GenericRepository<CallLog>, ICallLogDal
    {
        public List<CallLog> GetCallWithCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
