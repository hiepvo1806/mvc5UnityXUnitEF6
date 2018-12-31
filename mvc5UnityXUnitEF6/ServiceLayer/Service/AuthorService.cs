using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using ServiceLayer.Models;

namespace ServiceLayer.Service
{
    public class AuthorService : BaseService<AuthorVM,Author>, IAuthorService
    {
        public AuthorService(IMapper mapper, IAuthorRepo repo) : base(mapper, repo)
        {
            
        }
    }

    public interface IAuthorService : IBaseService<AuthorVM>
    {

    }
}
