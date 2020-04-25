using System;
using System.Collections.Generic;
using System.Text;

namespace SrcFramework.Core.Model
{
    public class BaseUser:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
    }
}

