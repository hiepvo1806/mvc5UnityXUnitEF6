using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repo
{
    public class BookRepo : BaseRepo<Book>, IBaseRepo<Book>
    {

        public override Book Edit(Book entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
