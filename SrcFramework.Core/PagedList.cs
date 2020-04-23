using System.Collections.Generic;

namespace SrcFramework.Core
{
    public class PagedList<T> where T:class
    {
        public int TotalPageCount { get; set; }
        public List<T> List { get; set; }
    }
}