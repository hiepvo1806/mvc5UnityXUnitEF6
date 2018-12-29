using System.Data.Entity;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext db = new BookstoreContext();
        public UnitOfWork()
        {

        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
