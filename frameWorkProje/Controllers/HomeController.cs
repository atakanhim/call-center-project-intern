using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {// Anasayfa
            return View();
        }
        [Authorize(Roles ="personel,admin")]
        public ActionResult Deneme()
        {// Anasayfa

            return View();
        }


    }
}