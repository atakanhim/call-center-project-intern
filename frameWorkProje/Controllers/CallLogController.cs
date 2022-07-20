using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    public class CallLogController : Controller
    {
        // GET: CallLog
        public ActionResult Index(int id = 0)
        {
            CallLogManager callLogManager = new CallLogManager(new EfCallLogRepository());
            var model = callLogManager.GetAllList();
            // cagrı detay sayfasu
            if (id > 0)
            {
                model = callLogManager.GetCallLogListVithFilter(x => x.CallLogId == id);
            }

            return View(model);
        }
  }  }