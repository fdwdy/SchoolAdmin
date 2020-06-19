using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using ItAcademy.SchoolAdmin.Web.App_Start;
using ItAcademy.SchoolAdmin.Web.Validators;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ItAcademy.SchoolAdmin.Web.Startup))]

namespace ItAcademy.SchoolAdmin.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes, app);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ValidationConfiguration();
        }

        private void ValidationConfiguration()
        {
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.ValidatorFactory = new ValidatorFactory();
            });
        }
    }
}
