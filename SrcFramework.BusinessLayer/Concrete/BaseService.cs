using System;
using Microsoft.EntityFrameworkCore;
using SrcFramework.Core.BusinessLayer.Abstract;
using SrcFramework.Core.Data.EntityFramework.Abstract;
using SrcFramework.Core.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SrcFramework.Core.BusinessLayer.Concrete
{
    public abstract class BaseService<TModel, TContext> : IBaseService<TModel> where TModel : BaseEntity where TContext : DbContext
    {
        protected readonly IUnitOfWork<TContext> UnitOfWork;
        //protected readonly IMapper Mapper;

        protected BaseService(IServiceProvider provider)
        {
            UnitOfWork = (IUnitOfWork<TContext>)provider.GetService(typeof(IUnitOfWork<TContext>));
        }

        public virtual void Insert(TModel model)
        {
            UnitOfWork.Repository<TModel>().Insert(model);
            UnitOfWork.SaveChanges();
        }

        public virtual Task InsertAsync(TModel model)
        {
            UnitOfWork.Repository<TModel>().Insert(model);
            return UnitOfWork.SaveChangesAsync();
        }

        public virtual void Delete(int id)
        {
            UnitOfWork.Repository<TModel>().Delete(id);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var model = await UnitOfWork.Repository<TModel>().GetAsync(id);
            UnitOfWork.Repository<TModel>().Delete(model);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual TModel Get(int id)
        {
            return UnitOfWork.Repository<TModel>().Get(id);
        }

        public virtual Task<TModel> GetAsync(int id)
        {
            return UnitOfWork.Repository<TModel>().GetAsync(id);
        }

        public virtual List<TModel> List()
        {
            return UnitOfWork.Repository<TModel>().GetList().ToList();
        }

        public virtual Task<List<TModel>> ListAsync()
        {
            return UnitOfWork.Repository<TModel>().GetListAsync();
        }

        public virtual void Update(TModel model)
        {
            UnitOfWork.Repository<TModel>().Update(model);
            UnitOfWork.SaveChanges();
        }

        public virtual Task UpdateAsync(TModel model)
        {
            UnitOfWork.Repository<TModel>().Update(model);
            return UnitOfWork.SaveChangesAsync();
        }
    }
}