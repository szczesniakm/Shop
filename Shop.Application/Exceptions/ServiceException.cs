using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Exceptions
{
    public class ServiceException : Exception
    {
        public string ErrorCode { get; }

        public ServiceException(string errorCode, string msg) : base(msg)
        {
            ErrorCode = errorCode;
        }
    }
}
