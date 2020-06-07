using System.Web.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IEmployeeService _empService;

        public HomeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        public virtual ActionResult Index()
        {
            return View();
        }
    }
}