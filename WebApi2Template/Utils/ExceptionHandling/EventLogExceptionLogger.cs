using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace WebApi2Template.Utils.ExceptionHandling
{

    public class EventLogExceptionLogger : IExceptionLogger
    {
        public EventLogExceptionLogger()
        {
        }
        public Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            new WebApiErrorEvent(context.Exception.Message, context.Request, 103005, context.Exception).Raise();
            return Task.FromResult(0);
        }
    }
}