using Microsoft.Owin.Security;
using MvcAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MvcAdmin.Controllers
{
    public class AuthController : Controller
    {
        public IAuthenticationManager Authentication
        {
            get
            {
                return this.Request.GetOwinContext().Authentication;
            }
        }
        // GET: Auth
        [HttpPost]
        public ActionResult SignIn(LoginInfo loginInfo, string returnUrl)
        {
            //returnUrl = Request.QueryString["returnUrl"];
            string username = "munachimsoemmanuel@gmail.com";
            string password = "admin";

            if (this.ModelState.IsValid)
            {
                if (username.Equals(loginInfo.Username) && password.Equals(loginInfo.Password))
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity("ApplicationCookie");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, username));

                    var ctxt = this.Request.GetOwinContext();
                    ctxt.Authentication.SignIn(claimsIdentity);

                    return Redirect(GetRedirectUrl(returnUrl));
                }
                else
                {
                    this.ModelState.AddModelError("", "Invalid Username or Password");
                }
            }

            return View();
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        [HttpGet]

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Authentication.SignOut("ApplicationCookie");
            return Redirect("signIn");
        }

    }
}