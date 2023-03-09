using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace frameWorkProje.Controllers
{
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        // GET: User
        // personeller listelenecek 
        UserManager userManager = new UserManager(new EfUserRepository());
        JobManager jobManager = new JobManager(new EfJobRepository());
        Context c = new Context();
        public ActionResult ListUsers()
        {
            var model = userManager.ListOnlyPersonel();
            return View(model);
        }
        public ActionResult ShowRapor(int id=0,string deger="")//user id aldık
        {
            var jobs = new List<Job>();        
            if (deger != "")
            {
                var tamamlananis = 0;
                int gun = Convert.ToInt32(deger);
                 jobs = c.Jobs.SqlQuery("select * from Jobs where userId='" + id + "' and  CreatingTime between Convert(date,'" + DateTime.Now.AddDays(-gun) + "',104) " +
                    " and Convert(date,'" + DateTime.Now + "',104) ").ToList();
                foreach (var item in jobs)
                {
                    if(item.JobStatus=="deaktif")
                        tamamlananis++;
                }
                ViewBag.count = jobs.Count;
                ViewBag.tamamlananis = tamamlananis;
                return View(jobs);
            }
            return View();
        }

    }
}