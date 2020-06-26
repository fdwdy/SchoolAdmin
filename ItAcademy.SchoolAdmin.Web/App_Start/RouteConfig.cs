using System.Web.Mvc;
using System.Web.Routing;
using Owin;

namespace ItAcademy.SchoolAdmin.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, IAppBuilder app)
        {
            app.MapSignalR();

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
              name: "CreateSubject",
              url: "Subject/Create",
              defaults: new { controller = "Subject", action = "CreateEdit" });

            routes.MapRoute(
              name: "EditSubject",
              url: "Subject/Edit/{id}",
              defaults: new { controller = "Subject", action = "CreateEdit", id = UrlParameter.Optional });
        }
    }
}
