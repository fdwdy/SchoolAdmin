using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.SignalR;
using ItAcademy.SchoolAdmin.Web.App_Start;
using ItAcademy.SchoolAdmin.Web.Validators;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ItAcademy.SchoolAdmin.Web.Startup))]

namespace ItAcademy.SchoolAdmin.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ValidationConfiguration();
            //app.UseAutofacMiddleware(new AutofacConfig());
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
