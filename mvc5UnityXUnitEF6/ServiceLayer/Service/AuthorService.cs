using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using ServiceLayer.Models;

namespace ServiceLayer.Service
{
    public class AuthorService : BaseService<AuthorVM,Author>, IAuthorService
    {
        public AuthorService()
        {
            repo = new AuthorRepo();
        }
    }

    public interface IAuthorService : IBaseService<AuthorVM>
    {

    }
}
