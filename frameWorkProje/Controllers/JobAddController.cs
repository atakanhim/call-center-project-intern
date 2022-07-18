﻿using BusinessLayer.Concreate;
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
        public ActionResult Index()
        {

            var values = cm.GetCallLogListWithCustomer();

            return View(values);
        }

        [HttpPost]
        public ActionResult CreateJob(Job job)
        {
            job.CreatingTime = DateTime.Now;
            job.UpdatingTime = DateTime.Now;
            job.UserId = 1;
            jm.JobAdd(job);
            // update edilecek çagrı seçildi çagrı durumu false olacak

            using (var db = new Context())
            {
                var user = db.CallLogs.Where(x => x.CallLogId == job.CallLogId).FirstOrDefault();

                user.CallLogStatus = true;

                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}