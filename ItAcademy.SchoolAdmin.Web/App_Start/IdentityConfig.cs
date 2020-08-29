using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace ItAcademy.SchoolAdmin.Web.App_Start
{
    public class IdentityConfig
    {
        private static IIdentityUnitOfWork _uow;

        public IdentityConfig(IIdentityUnitOfWork uow)
        {
            _uow = uow;
        }

        public static void SetupIdentity(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private static IUserService CreateUserService()
        {
            IUserServiceCreator serviceCreator = new UserServiceCreator();
            return serviceCreator.CreateUserService();
        }
    }
}