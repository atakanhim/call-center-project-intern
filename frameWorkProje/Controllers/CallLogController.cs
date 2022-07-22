using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{

    public class CallLogController : Controller
    {
        CallLogManager callLogManager = new CallLogManager(new EfCallLogRepository());
        JobManager jm = new JobManager(new EfJobRepository());

        // GET: CallLog
        public ActionResult Index(int id = 0, int persoId = 0)
        {
            var userId = Convert.ToInt32(Session["userId"]);// user ıd çagırıyoruz
            var roleId = Convert.ToInt32(Session["roleId"]);// rolu cagırıyoruz
            var model = new CallLog();
            if (id <= 0 || persoId <= 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (isAdmin())
                {
                    model = callLogManager.GetById(id);//bunu adminde çagırırız
                }
                else
                {
                    var jobList = jm.GetJobWithfilter("", null, "", false, Convert.ToInt32(Session["userId"]));
                    foreach (var item in jobList)
                    {
                        if (item.UserId == persoId && item.CallLogId == id)
                        {
                            model = callLogManager.GetById(id);//bunu adminde çagırırız
                            return View(model);
                        }
                       
                    }
                    return RedirectToAction("Index", "Home");// personel ise tüm herkesin cagrılarına gidemez.     
                    
                }

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CallLog call)
        {
            // veri geliyor
            var updaet = callLogManager.GetById(call.CallLogId);
            updaet.CallLogDesc = call.CallLogDesc;
            updaet.UpdatingTime = DateTime.Now;
            callLogManager.CallLogUpdate(updaet);


            return RedirectToAction("Index", "CallLog");
        }
        public ActionResult Cagrilar(int id = 0)
        {
            Context c = new Context();
            var callogList = new List<CallLog>();


            callogList = (from call in c.CallLogs
                          join cust in c.Customers
                          on call.CustomerId equals cust.CustomerId
                          where (call.CustomerId == id)
                          select call
                              ).ToList();

             
            return View(callogList);
        }
        public bool isAdmin()
        {
            if (Convert.ToInt32(Session["roleId"]) == 2)
            {
                return true;
            }
            return false;
        }
    }
}