﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Repo
{
    public interface IBaseRepo<T> where T : class
    {
        T Details(int? id);
        void Create(T entity);
        T Edit(T entity);
        void Delete(int? id);
        IQueryable<T> GetList(Expression<Func<T, bool>> predicate);
        DbContext GetCurrentDbContext();
    }
}