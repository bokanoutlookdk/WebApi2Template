using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace WebApi2Template.Utils.ExceptionHandling
{
    public class WindowsHandledErrorEventlLogger
    {
        private string source = "WebApi2Template.Exception";
        
        public WindowsHandledErrorEventlLogger()
        {
            //EventLog er static
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, "Application");
            }
        }

        public void WriteErrorLog(string message)
        {
            string prefixedMessag = "SOURCE : WebApi2Template\r\n";
            prefixedMessag = prefixedMessag + message;

            EventLog systemEventLog = new EventLog("Application");
            systemEventLog.Source = source;

            systemEventLog.WriteEntry(prefixedMessag, EventLogEntryType.Error, 150);
        }

    }
}