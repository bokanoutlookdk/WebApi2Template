using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi2Template.Utils.ExceptionHandling
{
	public class APIException : Exception
	{
        public APIException()
        {
        }

        public APIException(string message)
            : base(message)
        {
        }

        public APIException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}