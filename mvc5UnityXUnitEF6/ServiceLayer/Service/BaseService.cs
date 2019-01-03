using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using DataAccessLayer.Repo;
using System.Linq.Expressions;
using Unity.Attributes;

namespace ServiceLayer.Service
{
    public class BaseService<T, M> : IBaseService<T> where M : class
    {
        protected IBaseRepo<M> _repo { get; set; }
        //[Dependency]
        protected IMapper _mapper { get; set; }

        public BaseService(IMapper mapper, IBaseRepo<M> repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public void Create(T vm)
        {
            var entity = _mapper.Map<M>(vm);
            _repo.Create(entity);
        }

        public void Delete(int? id)
        {
            _repo.Delete(id);
        }

        public T Details(int? id)
        {
            return _mapper.Map<T>(_repo.Details(id));
        }

        public virtual T Edit(T input)
        {
            var entity = _mapper.Map<M>(input);
            _repo.Edit(entity);
            return input;
        }

        public IEnumerable<T> GetList()
        {
            var result =  _repo.GetList(null).ToList().Select(s=> _mapper.Map<T>(s));
            return result;
        }

        public DbContext GetCurrentDbContext()
        {
            if (_repo != null)
                return _repo.GetCurrentDbContext();
            throw new NullReferenceException();
        }
    }
}
