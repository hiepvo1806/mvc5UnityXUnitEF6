using AutoMapper;
using DataAccessLayer.Repo;

namespace ServiceLayer.Service
{
    public class BaseService<T, M> : IBaseService<T> where M : class
    {
        public IBaseRepo<M> repo { get; set; }
        public IMapper mapper { get; set; }

        public void Create(T vm)
        {
            var entity = mapper.Map<M>(vm);
            repo.Create(entity);
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public T Details(int? id)
        {
            throw new System.NotImplementedException();
        }

        public T Edit(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
