using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace WebApi2Template.Utils.ExceptionHandling
{
    internal class WebApiErrorEvent : WebRequestErrorEvent
    {
        protected internal WebApiErrorEvent(string message, object eventSource, int eventCode, Exception exception) : base(message, eventSource, eventCode, exception)
        {

        }
    }
}