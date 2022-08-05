﻿using BusinessLayer.Concreate;
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
           
            var values = jm.GetJobWithfilter(ad, numara, siralama, IsAdmin(), User.Identity.Name);
            if (IsAdmin())
            {
                values = jm.GetList(x=>x.JobStatus=="aktif");
                return View(values);
            }
            else
            {          
                if(values.Count > 0)
                    return View(values);
                else
                    return View(values);

            }
     

        }
      

        public bool IsAdmin()
        {
            if (System.Web.Security.Roles.GetRolesForUser().Single() == "admin")
            {

                return true;
            }
            return false;
        }
    }
}