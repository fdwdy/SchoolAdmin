using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public partial class EmployeeController : Controller
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Index()
        {
            IEnumerable<EmployeeDTO> emps = await _empService.GetAllAsync();
            return View(emps);
        }

        public async Task<ActionResult> GetEmployeeData()
        {
            IEnumerable<EmployeeDTO> emps = await _empService.GetAllAsync();
            return PartialView("_EmployeeData", emps);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDTO = await _empService.GetByIdAsync(id);
            if (employeeDTO == null)
            {
                return HttpNotFound();
            }
            return View(employeeDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _empService.RemoveByIdAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDTO employeeDTO = await _empService.GetByIdAsync(id);
            if (employeeDTO == null)
            {
                return HttpNotFound();
            }
            return View(employeeDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,BirthDate,Email,Phone")] EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(employeeDTO).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employeeDTO);
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
