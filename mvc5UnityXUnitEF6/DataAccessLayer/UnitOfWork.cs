using System.Data.Entity;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _db { get; set; }
        public UnitOfWork(DbContext db)
        {
            _db = db;
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
