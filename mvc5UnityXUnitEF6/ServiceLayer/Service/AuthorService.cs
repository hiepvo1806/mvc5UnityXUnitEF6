using DataAccessLayer.Repo;
using ServiceLayer.Models;

namespace ServiceLayer.Service
{
    public class AuthorService : IBaseService<AuthorVM>
    {
        public AuthorRepo authorRepo { get; set; }
        public AuthorService()
        {
            authorRepo = new AuthorRepo();
        }

        public AuthorVM Details(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(AuthorVM entity)
        {
            throw new System.NotImplementedException();
        }

        public AuthorVM Edit(AuthorVM entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}
