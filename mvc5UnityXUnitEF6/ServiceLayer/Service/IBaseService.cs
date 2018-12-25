using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ServiceLayer.Service
{
    public interface IBaseService<T>
    {
        T Details(int? id);
        void Create(T entity);
        T Edit(T entity);
        void Delete(int? id);
        IEnumerable<T> GetList();
    }
}