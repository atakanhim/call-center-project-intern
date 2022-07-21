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
        Context c = new Context();
        public User GetByName(string name) => c.Users.Where(x => x.UserName == name).FirstOrDefault();

        public List<User> ListOnlyPersonel() => c.Users.Where(x => x.UserPosition == "personel").ToList();
    }
}
