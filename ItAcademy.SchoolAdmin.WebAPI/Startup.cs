using Autofac.Integration.WebApi;
using ItAcademy.SchoolAdmin.WebAPI.App_Start;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(ItAcademy.SchoolAdmin.WebAPI.Startup))]

namespace ItAcademy.SchoolAdmin.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            SwaggerConfig.Register(config);

            var container = AutofacConfig.ConfigureContainer();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}
