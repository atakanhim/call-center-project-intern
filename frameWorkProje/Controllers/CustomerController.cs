using BusinessLayer.Concreate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
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
        public ActionResult CustomerAdd(long? id)
        {
            // callg witch customer yapacam
            if (id == null)
                return RedirectToAction("CreateJob", "JobAdd");

            ViewBag.tel = id;
            return View();
        }
        [HttpPost]
        public ActionResult CustomerAdd(Customer customer)
        {

            CustomerValidatior customerValidatior = new CustomerValidatior();

            ValidationResult results = customerValidatior.Validate(customer);
            if (results.IsValid)
            {

                cm.CustomerAdd(customer);
                using (var c = new Context())
                {


                    var value = c.CallLogs.Where(x => x.CalllNumber == customer.CustomerPhone).FirstOrDefault();
                    value.CustomerId = customer.CustomerId;// burda 1 kere value null geldi neden geldi acaba   

                    c.SaveChanges();
                    return RedirectToAction("CreateJob", "JobAdd");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                ViewBag.tel = customer.CustomerPhone;
                return View();
            }

        }
        [Authorize(Roles = "admin")]
        public ActionResult ListCustomers()
        {

            var customers = cm.CustomerList();
            return View(customers);
        }
    }
    // giriş yapan personelin id si ile listelettiğimiz listede ilk olarak o son 1 günde oluşturudugu işleri falan filan 
}