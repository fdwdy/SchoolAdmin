using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    [HandleError]
    public partial class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService, IMapper mapper)
        {
            _empService = empService;
            _mapper = mapper;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Index()
        {
            IEnumerable<Employee> emps = await _empService.GetAllAsync();
            IEnumerable<EmployeeListModel> models = _mapper.Map<IEnumerable<EmployeeListModel>>(emps);
            return View(models);
        }

        [HttpGet]
        public virtual async Task<ActionResult> GetEmployeeData()
        {
            IEnumerable<Employee> emps = await _empService.GetAllAsync();
            IEnumerable<EmployeeListModel> models = _mapper.Map<IEnumerable<EmployeeListModel>>(emps);
            return PartialView("_EmployeeData", models);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Create(Employee model)
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

        [HttpGet]
        public virtual async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeViewModel employee = await GetEmployeeViewModelById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        public virtual async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _empService.RemoveByIdAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public virtual async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeEditModel employee = await GetEmployeeEditModelById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(EmployeeEditModel employee)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<EmployeeEditModel, Employee>(employee);
                await _empService.UpdateAsync(model);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        [HttpGet]
        public virtual async Task<ActionResult> Search(string query)
        {
            IEnumerable<Employee> emps = await _empService.SearchAsync(query);
            IEnumerable<EmployeeListModel> models = _mapper.Map<IEnumerable<EmployeeListModel>>(emps);
            return PartialView("_EmployeeData", models);
        }

        public async Task<EmployeeViewModel> GetEmployeeViewModelById(string id)
        {
            return _mapper.Map<EmployeeViewModel>(await _empService.GetByIdAsync(id));
        }

        public async Task<EmployeeEditModel> GetEmployeeEditModelById(string id)
        {
            return _mapper.Map<EmployeeEditModel>(await _empService.GetByIdAsync(id));
        }
    }
}
