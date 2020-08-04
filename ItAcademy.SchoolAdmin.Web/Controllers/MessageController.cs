using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _empService;
        private readonly IMessageSenderService _msgService;

        public MessageController(IEmployeeService empService, IMapper mapper, IMessageSenderService msgService)
        {
            _empService = empService;
            _mapper = mapper;
            _msgService = msgService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}