using AutoMapper;
using DataAccessLayer.Models;
using DataAccessLayer.Repo;
using ServiceLayer.Models;
//using ServiceLayer.ExtensionMethod;
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

        public AuthorVM GetFirstObjBySelfExtensionMethod(int id)
        {
            return _mapper.Map<AuthorVM>(GetCurrentDbContext().Set<Author>().GetFirstCreateItem());
        }
    }

    public interface IAuthorService : IBaseService<AuthorVM>
    {
        AuthorVM ComplexAddedAuthorByExposeDbContext(AuthorVM vm);
        AuthorVM GetFirstObjBySelfExtensionMethod(int id);
    }
}
