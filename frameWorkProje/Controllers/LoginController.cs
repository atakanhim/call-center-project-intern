﻿using BusinessLayer.Concreate;
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
using System.Web.Security;

namespace frameWorkProje.Controllers
{
    [AllowAnonymous] 
    public class LoginController : Controller
    {
        // GET: Login
        UserManager um = new UserManager(new EfUserRepository());
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(UserLoginModel model)
        {

            using (var c = new Context())
            {

                var user = c.Users.Where(x => x.UserName == model.UserName && x.UserPassword == model.PassWord).FirstOrDefault();
                if (user != null)
                {
                    var roleId = 1; // 1 ise personel
                    if (user.UserPosition == "admin")
                        roleId = 2;// 2 ise admin
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Session.Add("userId", user.UserId);
                    Session.Add("roleId", roleId);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.mesaj = "Gecersiz Kullanici Adi";
                    return View(model);
                }


            }

        }
    }
}