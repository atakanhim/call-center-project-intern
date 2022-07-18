using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace frameWorkProje.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CustomerManager cm = new CustomerManager(new EfCustomerRepository());
        CallLogManager callmanager = new CallLogManager(new EfCallLogRepository());
        public ActionResult CustomerAdd(long? numra)
        {
            // callg witch customer yapacam
            if (numra == null)
                return RedirectToAction("Index","JobAdd");

            ViewBag.SuccessMessage = numra;
            return View(numra);
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {
            cm.CustomerAdd(customer);
            using (var c = new Context())
            {


                var value = c.CallLogs.Where(x => x.CalllNumber == customer.CustomerPhone).FirstOrDefault();
                value.CustomerId = customer.CustomerId;
                c.SaveChanges();
                return RedirectToAction("Index", "JobAdd");
            }

            // customer name kaldırılacak gerek yok 

            // customer eklendiyse call log veritabanında aynı telefon nosu bulunan veriyi
            // çekip customer ıdsini customer idsi olarak giricez
            //get ıd from calllog
        }
    }
}