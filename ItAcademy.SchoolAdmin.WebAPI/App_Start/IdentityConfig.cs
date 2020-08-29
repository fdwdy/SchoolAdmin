using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Services;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItAcademy.SchoolAdmin.WebAPI.App_Start
{
    public class IdentityConfig
    {
        public static void SetupIdentity(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
        }

        private static IUserService CreateUserService()
        {
            IUserServiceCreator serviceCreator = new UserServiceCreator();
            return serviceCreator.CreateUserService();
        }
    }
}