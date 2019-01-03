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

        public AuthorVM ComplexAddedAuthorByExposeDbContext(AuthorVM vm)
        {
            var ctx = GetCurrentDbContext() as BookstoreContext;
            var entity = _mapper.Map<Author>(vm);
            ctx.Authors.Add(entity);
            return vm;
        }
    }

    public interface IAuthorService : IBaseService<AuthorVM>
    {
        AuthorVM ComplexAddedAuthorByExposeDbContext(AuthorVM vm);
    }
}
