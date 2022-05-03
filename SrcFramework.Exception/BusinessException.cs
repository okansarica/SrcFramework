using System.Collections.Generic;

namespace SrcFramework.Exception
{
    public class BusinessException:System.Exception
    {
        public List<string> Parameters { get; set; }
        public BusinessException(string message):base(message)
        {
            
        }

        public BusinessException(string message, string parameter) : base(message)
        {
            Parameters = new List<string> { parameter };
        }

        public BusinessException(string message, List<string> parameters) : base(message)
        {
            Parameters = parameters;
        }

    }
}
