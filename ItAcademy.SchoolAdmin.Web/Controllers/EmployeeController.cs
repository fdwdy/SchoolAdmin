using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Enums;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    [Authorize]
    [HandleError]
    public partial class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _empService;
        private readonly IMessageService _msgService;

        public EmployeeController(IEmployeeService empService, IMapper mapper, IMessageService msgService)
        {
            _empService = empService;
            _mapper = mapper;
            _msgService = msgService;
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
            return PartialView(MVC.Employee.Views._EmployeeData, models);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            CreateEmployeeViewModel model = new CreateEmployeeViewModel();
            IEnumerable<PhoneViewModel> phonesList = new List<PhoneViewModel>()
            {
                new PhoneViewModel(),
            };
            model.Phones = phonesList;
            return View(model);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(CreateEmployeeViewModel employee)
        {
                if (ModelState.IsValid)
                {
                    var model = _mapper.Map<CreateEmployeeViewModel, Employee>(employee);
                    await _empService.AddAsync(model);
                    return RedirectToAction("Index");
                }

                return View(employee);
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
            return RedirectToAction(MVC.Employee.Actions.Index());
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
                return RedirectToAction(MVC.Employee.Actions.Index());
            }

            return View(employee);
        }

        public virtual async Task<ActionResult> BlankEditorRow()
        {
            return PartialView("_PhoneRow", new PhoneViewModel());
        }

        [HttpGet]
        public virtual async Task<ActionResult> Search(string query)
        {
            IEnumerable<Employee> emps = await _empService.SearchAsync(query);
            IEnumerable<EmployeeListModel> models = _mapper.Map<IEnumerable<EmployeeListModel>>(emps);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual async Task<ActionResult> SendMessage(string id)
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

            MessageViewModel msg = new MessageViewModel()
            {
                RecipientId = id,
            };

            if (employee.MessageType == MessageTypeEnum.Email)
            {
                msg.Length = 500;
                msg.Type = employee.MessageType;
            }
            else
            {
                msg.Length = 120;
                msg.Type = employee.MessageType;
            }

            return View(msg);
        }

        [HttpPost]
        public virtual async Task<ActionResult> SendMessage(MessageViewModel msg)
        {
            Employee employee = _mapper.Map<Employee>(await _empService.GetByIdAsync(msg.RecipientId));
            var result = _msgService.SendMessageToEmployee(msg.Text, employee);
            if (result.IsError)
            {
                ModelState.AddModelError("Warning", result.Message);
                return View(msg);
            }

            return RedirectToAction(MVC.Employee.Actions.Index());
        }

        public async Task<EmployeeViewModel> GetEmployeeViewModelById(string id)
        {
            return _mapper.Map<EmployeeViewModel>(await _empService.GetByIdAsync(id));
        }

        public async Task<EmployeeEditModel> GetEmployeeEditModelById(string id)
        {
            return _mapper.Map<EmployeeEditModel>(await _empService.GetByIdAsync(id));
        }

        [HttpPost]
        public virtual async Task<ActionResult> CheckMessageLength(string text, int length)
        {
            bool isLengthValid = text.Length > length ? true : false;
            var result = Json(!isLengthValid, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}
