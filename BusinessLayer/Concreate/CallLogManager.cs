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
    public class CallLogManager:ICallLogService
    {
        ICallLogDal _callLogdal;

        public CallLogManager(ICallLogDal callLogdal)
        {
            _callLogdal = callLogdal;
        }

        public void CallLogAdd(CallLog call)
        {
            throw new NotImplementedException();
        }

        public void CallLogDelete(CallLog call)
        {
            throw new NotImplementedException();
        }

        public List<CallLog> CallLogList()
        {
            return _callLogdal.GetListAll(x=>x.CallLogStatus==true);
        }

        public void CallLogUpdate(CallLog call)
        {
            _callLogdal.Update(call);
        }

        public CallLog GetById(int id)
        {
            return _callLogdal.GetById(id);
        }

        public List<CallLog> GetCallLogListWithCustomer()
        {
            return _callLogdal.GetCallWithCustomer();
        }

        public CallLog GetCallWithFilter(Expression<Func<CallLog, bool>> filter)
        {
            return _callLogdal.GetEntityWithFilter(filter);
        }
    }
}
