using System;
using SrcFramework.Core.Model;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SrcFramework.Core.Data.EntityFramework.Abstract
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext:DbContext
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity:BaseEntity;
        void SaveChanges();
        Task SaveChangesAsync();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
