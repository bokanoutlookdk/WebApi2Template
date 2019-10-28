using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApi2Template.Utils.ExceptionHandling
{
    // only this kind of NotFound implementation ist testable as IHttpActionResult!
    public class NotFoundTextResult : IHttpActionResult
    {
        public NotFoundTextResult(string message, HttpRequestMessage request)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            //if (request == null)
            //{
            //    throw new ArgumentNullException("request");
            //}

            Message = message;
        }

        public string Message { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(Message); // Put the message in the response body (text/plain content).
            //response.RequestMessage = Request;
            return response;
        }
    }
}