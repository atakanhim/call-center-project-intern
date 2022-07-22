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

namespace frameWorkProje.Controllers
{
    [Authorize(Roles = "personel,admin")]
    public class HomeController : Controller
    {
        JobManager jm = new JobManager(new EfJobRepository());
        public ActionResult Index(string ad = "", int? numara = null, string siralama = "")
        {
            var values = jm.GetJobWithfilter(ad, numara, siralama, isAdmin(), Convert.ToInt32(Session["userId"]));
            if (isAdmin())
            {
                values = jm.GetList();
                return View(values);
            }
            else
            {
                var values2 = jm.GetJobWithfilter("", null, "", isAdmin(), Convert.ToInt32(Session["userId"]));
                return View(values2);
            }
     

        }
        public ActionResult IndexDataTable(string ad = "", int? numara = null, string siralama = "")
        {

            if (ad == "" && numara == null && siralama == "")
            {

                if (isAdmin())
                {
                    var values = jm.GetList();
                    return View(values);
                }
                else
                {
                    var values2 = jm.GetJobWithfilter("", null, "", isAdmin(), Convert.ToInt32(Session["userId"]));
                    return View(values2);
                }

            }

            else
            {
                var values = jm.GetJobWithfilter(ad, numara, siralama, isAdmin(), Convert.ToInt32(Session["userId"]));
                return View(values);
            }

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