using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<EmployeeDTO> emps = _empService.GetAll();
            ViewBag.Model = emps;
            return View(emps);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Employee model = new Employee();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _empService.Add(model);
                    if (result.IsSuccess)
                    {
                        return RedirectToAction("Index");
                    }

                    TempData["ErrorMessage"] = result.Message;
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
