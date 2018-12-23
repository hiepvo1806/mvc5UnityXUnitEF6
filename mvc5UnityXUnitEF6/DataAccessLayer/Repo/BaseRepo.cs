using System;
using System.Data.Entity;

namespace DataAccessLayer.Repo
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        private BookstoreContext db = new BookstoreContext();
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

        public T Edit(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }


}
