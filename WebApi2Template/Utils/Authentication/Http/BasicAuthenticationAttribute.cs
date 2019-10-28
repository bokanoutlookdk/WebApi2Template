using System;
using System.Collections.Generic;
using System.Text;
using DoCAS.Service.Katalog.Utils.Unity;
using WebApi2Template.Properties;

namespace DoCAS.Service.Katalog.Utils.Authentication.Http
{
    //https://stevescodingblog.co.uk/basic-authentication-with-asp-net-webapi/
    public class BasicAuthenticationAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (Settings.Default.EnableAuth)
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
            else
            {
                string authToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                //string username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
                string password = decodedToken.Split(':')[1];

                AuthService authService = (AuthService)DependencyFactory.CreateIAuthServiceContext();
                authService.HttpHeaderPwdValue = password;

                if (!authService.IsAuthSucces())
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }
        }

    }
}
