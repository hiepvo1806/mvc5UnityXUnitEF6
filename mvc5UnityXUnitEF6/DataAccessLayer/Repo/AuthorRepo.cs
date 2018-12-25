using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repo
{
    public class AuthorRepo : BaseRepo<Author>, IBaseRepo<Author>
    {
        public override Author Edit(Author entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
