using System;

namespace SrcFramework.Core.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastModificationDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
