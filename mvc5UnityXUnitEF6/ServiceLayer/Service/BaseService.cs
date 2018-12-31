using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataAccessLayer.Repo;
using System.Linq.Expressions;

namespace ServiceLayer.Service
{
    public class BaseService<T, M> : IBaseService<T> where M : class
    {
        protected IBaseRepo<M> repo { get; set; }
        protected IMapper mapper { get; set; }

        public void Create(T vm)
        {
            var entity = mapper.Map<M>(vm);
            repo.Create(entity);
        }

        public void Delete(int? id)
        {
            repo.Delete(id);
        }

        public T Details(int? id)
        {
            return mapper.Map<T>(repo.Details(id));
        }

        public virtual T Edit(T input)
        {
            var entity = mapper.Map<M>(input);
            repo.Edit(entity);
            return input;
        }

        public IEnumerable<T> GetList()
        {
            var result =  repo.GetList(null).ToList().Select(s=> mapper.Map<T>(s));
            return result;
        }
    }
}
