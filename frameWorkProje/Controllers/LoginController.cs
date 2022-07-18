using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using frameWorkProje.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{

    public class LoginController : Controller
    {
        // GET: Login
        UserManager um = new UserManager(new EfUserRepository());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {
             var userKontrol = um.GetByName(model.UserName);
            if (userKontrol != null)
            {
                return View(model);
            }
            return View(model);
        }
    }
}