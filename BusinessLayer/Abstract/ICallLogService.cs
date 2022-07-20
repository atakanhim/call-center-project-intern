using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICallLogService
    {
        void CallLogAdd(CallLog call);
        void CallLogDelete(CallLog call);
        void CallLogUpdate(CallLog call);
        List<CallLog> CallLogList();
        CallLog GetById(int id);
        CallLog GetCallWithFilter(Expression<Func<CallLog, bool>> filter);
        List<CallLog> GetCallLogListWithCustomer();
    }
}
