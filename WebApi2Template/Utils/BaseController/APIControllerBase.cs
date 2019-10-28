using WebApi2Template.Utils.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi2Template.Utils.BaseController
{
    // only this kind of NotFound implementation ist testable as IHttpActionResult!
    public class APIControllerBase : ApiController
    {
        public  NotFoundTextResult NotFound(string message)
        {
            return new NotFoundTextResult(message, this.Request);

        }
    }
}