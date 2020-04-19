using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SrcFramework.Core.Data.EntityFramework.Abstract;
using SrcFramework.Core.Model;

namespace SrcFramework.Core.Data.EntityFramework.Concrete
{
    public class RepositoryEntityFramework<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
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
            entity.LastModificationDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            
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
            entity.LastModificationDate = DateTime.Now;
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

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = (IQueryable<TEntity>) _entities;
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

        public IEnumerable<TEntity> GetList(List<int> idList, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = (IQueryable<TEntity>) _entities;
            if (idList != null || idList.Count <= 0)
            {
                entities = entities.Where(p => idList.Contains(p.Id));
            }
            else
            {
                return new List<TEntity>();
            }

            foreach (var child in children)
            {
                entities = entities.Include(child);
            }

            return entities;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = _entities.Where(filter);
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

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = _entities.Where(filter);
            foreach (var child in children)
            {
                entities = entities.Include(child);
            }

            return entities.FirstOrDefaultAsync();
        }

        public Task<TEntity> GetAsync(int id, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = _entities.Where(p => p.Id == id);
            entities = children.Aggregate(entities, (current, child) => current.Include(child));
            return entities.FirstOrDefaultAsync();
        }

        public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = (IQueryable<TEntity>) _entities;
            if (filter != null)
            {
                entities = entities.Where(filter);
            }

            foreach (var child in children)
            {
                entities = entities.Include(child);
            }

            return entities.ToListAsync();
        }

        public Task<List<TEntity>> GetListAsync(List<int> idList, params Expression<Func<TEntity, object>>[] children)
        {
            var entities = (IQueryable<TEntity>) _entities;
            if (idList != null && idList.Count>0)
            {
                entities = entities.Where(p=>idList.Contains(p.Id));
            }
            else
            {
                return Task.FromResult( new List<TEntity>());
            }

            foreach (var child in children)
            {
                entities = entities.Include(child);
            }

            return entities.ToListAsync();
        }

        public IQueryable<TEntity> Queryable => _entities.AsNoTracking();
    }
}