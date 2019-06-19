using System;
using SrcFramework.Core.Model;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace SrcFramework.Core.Data.EntityFramework.Abstract
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity :class, IEntity, new();
        void SaveChanges();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
