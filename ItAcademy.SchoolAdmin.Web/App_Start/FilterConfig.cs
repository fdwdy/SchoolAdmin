using System.Web.Mvc;
using ItAcademy.SchoolAdmin.Web.Filters;

namespace ItAcademy.SchoolAdmin.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new NLogExceptionHandlerAttribute());
        }
    }
}
