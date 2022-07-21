using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
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
            // bu id nin aldığı işleri listeleyeceğiz
            var jobs = c.Jobs.SqlQuery("select * from Jobs where userId='" + id + "' and CreatingTime=Convert(date,'" + DateTime.Now.ToShortDateString()+ "',104)").ToList();
            
            return View(jobs);
        }

    }
}