using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repo
{
    public class BookShopRepo : BaseRepo<BookShop>, IBaseRepo<BookShop>
    {
        public override BookShop Edit(BookShop entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
