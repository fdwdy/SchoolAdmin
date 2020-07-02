using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public partial class WorkerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkerService _wrkService;
        private readonly IEmployeeService _empService;
        private readonly IPositionService _posService;

        public WorkerController(IPositionService posService, IWorkerService wrkService, IEmployeeService empService, IMapper mapper)
        {
            _mapper = mapper;
            _wrkService = wrkService;
            _empService = empService;
            _posService = posService;
        }

        [HttpGet]
        public virtual async Task<ActionResult> EditEmployee(string id)
        {
            var employees = _mapper.Map<IEnumerable<EmployeeSelectViewModel>>(await _empService.GetAllAsync());
            var workers = await _wrkService.GetWorkers(id);
            var position = await _posService.GetByIdAsync(id);
            foreach (var emp in employees)
            {
                if (workers.EmployeeIds.Contains(emp.Id))
                {
                    emp.IsSelected = true;
                }
            }

            WorkerViewModel worker = new WorkerViewModel
            {
                PositionId = position.Id,
                Employees = employees,
                PositionName = position.Name,
                MaxEmployees = position.MaxEmployees
            };
            return View(MVC.Worker.Views.EditForPosition, worker);
        }

        [HttpPost]
        public virtual async Task<ActionResult> EditEmployee(string id, string[] selectedEmployees)
        {
            await _wrkService.SaveWorkers(id, selectedEmployees);
            return RedirectToAction(MVC.Position.Actions.Index());
        }
    }
}