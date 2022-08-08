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
        public FrameWorkProjeSingleton()
        {
            SetLoginUser();
        }
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
            currentUSer = user;
        }
      

       
    }
}