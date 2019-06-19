using System;
using System.Collections.Generic;
using System.Text;

namespace SrcFramework.Exception
{
    public class BusinessException:System.Exception
    {
        public BusinessException(string message):base(message)
        {
            
        }
    }
}
