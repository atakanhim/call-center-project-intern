using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using frameWorkProje.Models;
using frameWorkProje.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace frameWorkProje.Controllers
{
    
    public class HomeController : Controller
    {
        
       readonly JobManager jm = new JobManager(new EfJobRepository());

        
        public ActionResult Index()
        {
            FrameWorkProjeSingleton.Instance.SetLoginUser();
            var values = jm.GetJobWithfilter( IsAdmin(), User.Identity.Name);
            if (IsAdmin())
            {
                values = jm.GetList(x=>x.JobStatus=="aktif");
                return View(values);
            }
            return View(values);
        }
        public bool IsAdmin() => FrameWorkProjeSingleton.Instance.isAdmin();


    }
}