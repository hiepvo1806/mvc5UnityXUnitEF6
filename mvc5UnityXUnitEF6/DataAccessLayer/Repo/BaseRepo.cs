using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repo
{
    public abstract class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected BookstoreContext db = new BookstoreContext();
        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            T entity = db.Set<T>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            db.Set<T>().Remove(entity);
        }

        public T Details(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }
            T entity = db.Set<T>().Find(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }
            return entity;
        }

        public abstract T Edit(T entity);
        //{
        //    db.Entry(entity).State = EntityState.Modified;
        //    return entity;
        //}

        public IQueryable<T> GetList(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null) return db.Set<T>();
            return db.Set<T>().Where(predicate);
        }

        public int SaveChanges()
        {
            return db.SaveChanges();
        }
    }
}
