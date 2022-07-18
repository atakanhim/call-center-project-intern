using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    [Authorize(Roles = "personel,admin")]
    public class HomeController : Controller
    {
        JobManager jm = new JobManager(new EfJobRepository());

        public ActionResult Index(string ad = "", int? numara = null, string abc = "")
        {
              var values = jm.GetJobListWithUser();
                return View(values);

        }



     
        public ActionResult Deneme()
        {// Anasayfa

            return View();
        }


    }
}