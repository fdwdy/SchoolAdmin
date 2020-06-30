using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public partial class TeacherController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITeacherService _tchService;
        private readonly IEmployeeService _empService;

        public TeacherController(ITeacherService tchService, IEmployeeService empService, IMapper mapper)
        {
            _mapper = mapper;
            _tchService = tchService;
            _empService = empService;
        }

        [HttpGet]
        public virtual async Task<ActionResult> EditEmployee(string id)
        {
            var employees = _mapper.Map<IEnumerable<EmployeeSelectViewModel>>(await _empService.GetAllAsync());
            var subjectTeachers = await _tchService.GetSubjectTeachers(id);
            foreach (var emp in employees)
            {
                if (subjectTeachers.EmployeeIds.Contains(emp.Id))
                {
                    emp.IsSelected = true;
                }
            }

            SubjectTeachersViewModel subjectTeacher = new SubjectTeachersViewModel
            {
                SubjectId = subjectTeachers.SubjectId,
                Employees = employees,
                SubjectName = subjectTeachers.SubjectName,
            };
            return View(MVC.Teacher.Views.EditForSubject, subjectTeacher);
        }

        [HttpPost]
        public virtual async Task<ActionResult> EditEmployee(string id, string[] selectedEmployees)
        {
            ////List<Employee> emps = new List<Employee>();
            ////for (int i = 0; i < selectedEmployees.Count(); i++)
            ////{
            ////    emps.Add(await _empService.GetByIdAsync(selectedEmployees[i]));
            ////}

            ////await _tchService.SaveSubjectTeachers();
            return RedirectToAction("Details", "Subject", new { id });
        }
    }
}