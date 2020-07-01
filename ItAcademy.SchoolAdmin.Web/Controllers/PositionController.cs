using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public class PositionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _posService;

        public PositionController(IPositionService posService, IMapper mapper)
        {
            _posService = posService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<Position> positions = await _posService.GetAllAsync();
            IEnumerable<PositionViewModel> models = _mapper.Map<IEnumerable<PositionViewModel>>(positions);
            return View(models);
        }
    }
}