using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public void Delete(T t)
        {
            var deletedEntity = c.Entry(t);
            deletedEntity.State = EntityState.Deleted;
            // _object.Remove(t);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public List<T> GetListAll()
        {
            return _object.ToList();
        }

        public void Insert(T t)
        {
            _object.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {

            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {

            c.SaveChanges();
        }
    }
}
