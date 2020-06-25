using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Web.Models;

namespace ItAcademy.SchoolAdmin.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _sbjService;

        public SubjectController(ISubjectService sbjService, IMapper mapper)
        {
            _sbjService = sbjService;
            _mapper = mapper;
        }

        [HttpGet]
        public async virtual Task<ActionResult> Index()
        {
            IEnumerable<Subject> sbj = await _sbjService.GetAllAsync();
            IEnumerable<SubjectViewModel> models = _mapper.Map<IEnumerable<SubjectViewModel>>(sbj);
            return View(models);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            SubjectViewModel model = new SubjectViewModel();
            return View("CreateEdit", model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));

            if (sbj == null)
            {
                return HttpNotFound();
            }

            return View("CreateEdit", sbj);
        }

        [HttpPost]
        public virtual ActionResult Create(Subject model)
        {
            if (ModelState.IsValid)
            {
                var result = _sbjService.Add(model);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }

                TempData["ErrorMessage"] = result.Message;
            }

            return View();
        }
    }
}