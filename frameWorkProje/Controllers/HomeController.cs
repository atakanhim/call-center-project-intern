using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using frameWorkProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace frameWorkProje.Controllers
{
    [Authorize(Roles = "personel,admin")]
    public class HomeController : Controller
    {
       readonly JobManager jm = new JobManager(new EfJobRepository());
        public ActionResult Index(string ad = "", int? numara = null, string siralama = "")
        {
            var values = jm.GetJobWithfilter(ad, numara, siralama, IsAdmin(), Convert.ToInt32(Session["userId"]));
            if (IsAdmin())
            {
                values = jm.GetList(x=>x.JobStatus=="aktif");
                return View(values);
            }
            else
            {
                
                var values2 = jm.GetJobWithfilter("", null, "", IsAdmin(), Convert.ToInt32(Session["userId"]));
                if(values2.Count > 0)
                    return View(values2);
                else
                {
                    // hata mesajı
                    return View(values);
                }
                    

            }
     

        }
        public ActionResult IndexDataTable(string ad = "", int? numara = null, string siralama = "")
        {

            if (ad == "" && numara == null && siralama == "")
            {

                if (IsAdmin())
                {
                    var values = jm.GetList();
                    return View(values);
                }
                else
                {
                    var values2 = jm.GetJobWithfilter("", null, "", IsAdmin(), Convert.ToInt32(Session["userId"]));
                    return View(values2);
                }

            }

            else
            {
                var values = jm.GetJobWithfilter(ad, numara, siralama, IsAdmin(), Convert.ToInt32(Session["userId"]));
                return View(values);
            }

        }

        public bool IsAdmin()
        {
            if (Convert.ToInt32(Session["roleId"]) == 2)
            {

                return true;
            }
            return false;
        }
    }
}