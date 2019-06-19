﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SrcFramework.Core.Model;

namespace SrcFramework.Core.Data.EntityFramework.Abstract
{
    public interface IRepository<T> where T : IEntity, new()
    {
        T Find(params object[] keyValues);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(object id);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void DeleteRange(Expression<Func<T, bool>> filter);
        IQueryable<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] children);
        T Get(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] children);
        T Get(int id, params Expression<Func<T, object>>[] children);
    }
}
