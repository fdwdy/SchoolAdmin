using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FluentValidation.Mvc;
using ItAcademy.SchoolAdmin.Web.App_Start;
using ItAcademy.SchoolAdmin.Web.Validators;

namespace ItAcademy.SchoolAdmin.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //RouteTable.Routes.MapHubs();
            //AutofacConfig.ConfigureContainer();
            //AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //ValidationConfiguration();
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
