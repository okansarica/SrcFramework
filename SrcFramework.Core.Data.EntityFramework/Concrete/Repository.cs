﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SrcFramework.Core.Data.EntityFramework.Abstract;
using SrcFramework.Core.Model;

namespace SrcFramework.Core.Data.EntityFramework.Concrete
{
    public class RepositoryEntityFramework<TEntity> : IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DbSet<TEntity> _entities;

        public RepositoryEntityFramework(DbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public TEntity Find(params object[] keyValues)
        {
            return _entities.Find(keyValues);
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);
        }

        public void Delete(object id)
        {
            var entity = _entities.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> filter)
        {
            foreach (var entity in _entities.Where(filter))
            {
                Delete(entity);
            }
        }

        public IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = (IQueryable<TEntity>)_entities;
            if (filter != null)
            {
                entities = entities.Where(filter);
            }
            foreach (var child in children)
            {
                entities = entities.Include(child);
            }
            return entities;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            IQueryable<TEntity> entities = _entities.Where(filter);
            foreach (var child in children)
            {
                entities = entities.Include(child);
            }
            return entities.FirstOrDefault();
        }

        public TEntity Get(int id, params Expression<Func<TEntity, object>>[] children)
        {
            return _entities.SingleOrDefault(p => p.Id == id);                        
        }
    }
}
