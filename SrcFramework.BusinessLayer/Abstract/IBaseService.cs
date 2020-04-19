using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SrcFramework.Core.BusinessLayer.Abstract
{
    public interface IBaseService<T>
    {
//        void Insert(T model);
//        void Update(T model);
//        T Get(int id);
//        List<T> List();
//        void Delete(int id);

        Task InsertAsync(T model);
        Task UpdateAsync(T model);
        Task<T> GetAsync(int id);
        Task<List<T>> ListAsync();
        Task DeleteAsync(int id);
    }
}
