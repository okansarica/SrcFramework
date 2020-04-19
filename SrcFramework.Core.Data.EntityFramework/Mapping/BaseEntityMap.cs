using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SrcFramework.Core.Model;

namespace SrcFramework.Core.Data.EntityFramework.Mapping
{
    //core 2.0
    public class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.ToTable(typeof(T).Name);
        }
    }
}
