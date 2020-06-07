using System.Web.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _empService;

        public HomeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}