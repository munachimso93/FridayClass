using Microsoft.Owin;
using MvcAdmin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(StartUp))]
namespace MvcAdmin
{
    public partial class StartUp
    {
        public static void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}