using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        // personeller listelenecek 
        UserManager userManager = new UserManager(new EfUserRepository());

        [Authorize(Roles = "admin")]
        public ActionResult ListUsers()
        {

            var model = userManager.ListOnlyPersonel();
            return View(model);
        }

    }
}