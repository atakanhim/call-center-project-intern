using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace frameWorkProje.Singleton
{
    public class FrameWorkProjeSingleton
    {
        UserManager userManager = new UserManager(new EfUserRepository());
        public User currentUSer { get; set; }
        private FrameWorkProjeSingleton() { }
 
        private static FrameWorkProjeSingleton instance = null;
        public static FrameWorkProjeSingleton Instance
        {
            get
            {

                if (instance == null)
                {
                    instance = new FrameWorkProjeSingleton();
                }
                return instance;

            }
        }
        public void SetLoginUser()
        {
            var user = userManager.GetByName(HttpContext.Current.User.Identity.Name.ToString());
            currentUSer = user;// 1 kere çalıştıgı için sıkıntııı , gir çık yapıncaada çalışması lazım
        }

        public bool isAdmin()
        {
           
            if (currentUSer.UserPosition=="admin")
            {
                return true;
            }
            return false;
        }

    }
}