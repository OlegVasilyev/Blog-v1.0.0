using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationLayer.BLL.Interfaces;
using AuthenticationLayer.BLL.Services;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using EpamBlog.App_Start;
using Microsoft.AspNet.Identity;
using WebGrease;

[assembly: OwinStartup(typeof(Startup))]

namespace EpamBlog.App_Start
{
    public class Startup
    {
        readonly IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("AuthenticationContext");
        }
    }
}