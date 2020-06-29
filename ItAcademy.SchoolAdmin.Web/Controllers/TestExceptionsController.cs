using System;
using System.Web;
using System.Web.Mvc;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    [HandleError]
    public partial class TestExceptionsController : Controller
    {
        [HttpGet]
        public virtual ActionResult Index()
        {
            throw new HttpException(404, "Not found");
        }

        public virtual ActionResult Employees()
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }
}