using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    public class CallLogController : Controller
    {
        CallLogManager callLogManager = new CallLogManager(new EfCallLogRepository());
        // GET: CallLog
        public ActionResult Index(int id = 0)
        {
            if (id <= 0)
            {
                return RedirectToAction("Index","Home");
            }
            var model = callLogManager.GetById(id);
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CallLog call)
        {
   // veri geliyor

            return View();
        }
        public ActionResult CallLogDetay(int id = 0)
        {
           
          
            return View();
           
        }
    }  }