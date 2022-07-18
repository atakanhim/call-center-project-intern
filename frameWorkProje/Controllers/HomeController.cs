using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {// Anasayfa
            return View();
        }

      
    }
}