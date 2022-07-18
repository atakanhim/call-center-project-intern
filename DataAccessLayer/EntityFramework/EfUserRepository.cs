using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<User>, IUserDal
    {
        public User GetByName(string name)
        {
            using (var c = new Context())
            {

                return c.Users.Where(x => x.UserName == name).FirstOrDefault();
            }
        }
    }
}
