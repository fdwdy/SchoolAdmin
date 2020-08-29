using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    [Authorize]
    public partial class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _empService;
        private readonly IMessageService _msgService;

        public MessageController(IEmployeeService empService, IMapper mapper, IMessageService msgService)
        {
            _empService = empService;
            _mapper = mapper;
            _msgService = msgService;
        }

        public virtual async Task<ActionResult> Index()
        {
            IEnumerable<MessageWithRecipientName> emps = await _msgService.GetAllSortedByStatusAndTimeAsync();
            IEnumerable<MessageWithRecipient> models = _mapper.Map<IEnumerable<MessageWithRecipient>>(emps);
            return View(models);
        }

        [HttpPost]
        public virtual async Task<ActionResult> ResendMessage(string id)
        {
            var msg = await _msgService.GetByIdAsync(id);
            var employee = _mapper.Map<Employee>(await _empService.GetByIdAsync(msg.RecipientId));
            var result = _msgService.SendMessageToEmployee(msg.Text, employee);
            return Json(result.Data);
        }
    }
}