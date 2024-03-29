﻿using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using frameWorkProje.Singleton;
using System;
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
 
        public ActionResult JobDelete(int id)
        {
            // job status false yapılacak
            // job idsini alıp ordan calllog calllog durumu false olacak falan filan
            var jap = jm.GetByFilter(x => x.JobId == id);

            // iş durumu false olacak

            jm.ChangeJubStatus(jap.JobId);

            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        public ActionResult JobUpdate(Job job)
        {
            // job status false yapılacak
            // job idsini alıp ordan calllog calllog durumu false olacak falan filan
            var jap = jm.GetByFilter(x => x.JobId == job.JobId);
            jap.JobDescription = job.JobDescription;
            jap.JobMethods = job.JobMethods;
            jap.UpdatingTime = DateTime.Now;
            jap.IsImportant = Convert.ToBoolean(job.IsImportant);

            // iş durumu false olacak

            jm.JobUpdate(jap);

            return RedirectToAction("Index", "CallLog", new { id = jap.CallLogId, persoId = FrameWorkProjeSingleton.Instance.currentUSer.UserId });
      
        }

        [HttpPost]
        public ActionResult CreateJob(Job job)// 
        {
           // var sessionUserId = Convert.ToInt32(Session["userId"]);
           // burda singleton ile gelen kişi disini veritabanında donum gelen userun bilgilerini database olarak tutacğız.
            if (job.CallLogId == 0)
            {
                // çagrı seçmemiş demektir
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
                    DateTime date = DateTime.Now;
                    var shortDate = date.Date;
                    job.CreatingTime = shortDate;
                    job.UpdatingTime = shortDate;
                    job.JobStatus = "aktif";

                    job.UserId = FrameWorkProjeSingleton.Instance.currentUSer.UserId;// personel id giren kişi çekilece


                    jm.JobAdd(job);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}