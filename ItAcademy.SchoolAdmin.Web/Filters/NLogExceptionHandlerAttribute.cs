using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ItAcademy.SchoolAdmin.Web.Filters
{
    public class NLogExceptionHandlerAttribute : HandleErrorAttribute
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            logger.Error($"Exception info:", filterContext.Exception);

            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                logger.Info($"Handled exception {filterContext.Exception.Message} in {filterContext.Controller}");
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

            logger.Info($"Unhandled exception {filterContext.Exception.Message} in {filterContext.Controller}");

            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();

            //base.OnException(filterContext);
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