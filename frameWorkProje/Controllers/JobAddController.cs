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
    public class JobAddController : Controller
    {
        JobManager jm = new JobManager(new EfJobRepository());
        CallLogManager cm = new CallLogManager(new EfCallLogRepository());
        public ActionResult CreateJob()
        {
  
            var values = cm.CallLogList();

            return View(values);
        }


        [HttpPost]
        public ActionResult CreateJob(Job job)// 
        {

            if (job.CallLogId == 0)
            {
                // js ile kontrol ediliyor zaten burasıda 2. kontrol yeri
            }
            else
            {

                using (var db = new Context())
                {
                    var user = cm.GetCallWithFilter(x => x.CallLogId == job.CallLogId);
                    user.CallLogStatus = false;// cagri durumu false oluyor böylece yanıtlanmıs demek
                    cm.CallLogUpdate(user);
                    // daha sonra job ekleniyor 
                    job.CreatingTime = DateTime.Now;
                    job.UpdatingTime = DateTime.Now;
                    job.UserId = 1;// personel id giren kişi çekilece


                    jm.JobAdd(job);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}