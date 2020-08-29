using System.Web;
using System.Web.Mvc;
using NLog;

namespace ItAcademy.SchoolAdmin.Web.Filters
{
    public class NLogExceptionHandlerAttribute : HandleErrorAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            Logger.Error($"Exception info:", filterContext.Exception);
            Logger.Info($"Current user: {HttpContext.Current.User.Identity.Name}");

            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                Logger.Info($"Handled exception {filterContext.Exception.Message} in {filterContext.Controller}");
                return;
            }

            if (filterContext.Exception is HttpException)
            {
                var statusCode = ((HttpException)filterContext.Exception).GetHttpCode();
                filterContext.Result = GetErrorView(statusCode);
            }
            else
            {
                filterContext.Result = new ViewResult() { ViewName = "Error" };
            }

            Logger.Info($"Unhandled exception {filterContext.Exception.Message} in {filterContext.Controller}");

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
        }

        private ActionResult GetErrorView(int statusCode)
        {
            var viewName = "Error" + statusCode.ToString();

            var result = new ViewResult
            {
                ViewName = viewName,
            };

            return result;
        }
    }
}