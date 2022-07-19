using BusinessLayer.Concreate;
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
        CustomerManager customerManager = new CustomerManager(new EfCustomerRepository());  

        public ActionResult Index(string ad = "", int? numara = null, string abc = "")
        {
            if (ad == "" && numara == null && abc == "")
            {
                var values = jm.GetList();
                return View(values);

            }
            else
            {

     
                var values = jm.GetJobWithfilter(ad, numara, abc);
                return View(values);
            }

        }



     
        public ActionResult Deneme()
        {// Anasayfa
            // 2 modeli anı sayfaya gondermeye calışmak 
            var value1 = jm.GetList();
            var value2 = customerManager.CustomerList();
            ViewModel mymodel = new ViewModel();
            mymodel.Customers = value2;
            mymodel.Jobs=value1;
            return View(mymodel);
        }


    }
}