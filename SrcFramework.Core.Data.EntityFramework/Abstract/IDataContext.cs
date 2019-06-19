using System;

namespace SrcFramework.Core.Data.EntityFramework.Abstract
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
    }
}
