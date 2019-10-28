using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi2Template.Interfaces.Authentication;

namespace DoCAS.Service.Katalog.Utils.Authentication.Http
{
    public class AuthService : IAuthService
    {
        public string HttpHeaderPwdValue { get; set; }
        private string MySecret { get => "Spurs4Ever"; }

        public bool IsAuthSucces()
        {
            if (string.IsNullOrEmpty(HttpHeaderPwdValue))
                throw new Exception("Http Header password value is required");

            return HttpHeaderPwdValue == MySecret;

        }

    }

    
}