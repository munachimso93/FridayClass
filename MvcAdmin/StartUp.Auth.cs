using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAdmin
{
    public partial class StartUp
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            var option = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "AdminMvc",
                LoginPath = new PathString("/Auth/SignIn"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30),
                SlidingExpiration = true

            };
            app.UseCookieAuthentication(option);
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            
            app.UseGoogleAuthentication(
           clientId: "1055603051371 - 2jqkde607gmb1r54ltq67vtn0ufmrpij.apps.googleusercontent.com",
            clientSecret: "WM4m3xuR1Pqg2e7x8aRZKgpZ");
        }
    }
}