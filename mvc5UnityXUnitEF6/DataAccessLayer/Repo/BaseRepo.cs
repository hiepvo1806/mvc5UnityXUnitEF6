using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {        
        protected DbContext _db { get; set; }
        public BaseRepo(DbContext db)
        {
            _db = db;
        }

        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            T entity = _db.Set<T>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            _db.Set<T>().Remove(entity);
        }

        public T Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            T entity = _db.Set<T>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            return entity;
        }

        public virtual T Edit(T entity) {
            throw new NotImplementedException();
        }


        public IQueryable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) return _db.Set<T>();
            return _db.Set<T>().Where(predicate);
        }

        //Changed protect to public for XUnit experiment.
        public DbContext GetCurrentDbContext()
        {
            return _db;
        }
    }
}
