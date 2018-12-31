using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repo
{
    public class AuthorRepo : BaseRepo<Author>, IAuthorRepo
    {
        public AuthorRepo(DbContext db) : base(db)
        {

        }
        public override Author Edit(Author input)
        {
            var entity = this.Details(input.Id);
            entity.Age = input.Age;
            entity.Books = input.Books;
            entity.FirstName = input.FirstName;
            entity.LastName = input.LastName;
            //_db.Entry(input).State = EntityState.Modified;
            return entity;
        }
    }

    public interface IAuthorRepo : IBaseRepo<Author>
    {

    }
}
