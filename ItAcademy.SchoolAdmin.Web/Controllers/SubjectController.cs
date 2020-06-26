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
        public async virtual Task<ActionResult> Create()
        {
            SubjectViewModel model = new SubjectViewModel();
            return View("CreateEdit", model);
        }

        [HttpGet]
        public async virtual Task<ActionResult> Edit(string id)
        {
            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));
            return View("CreateEdit", sbj);
        }

        [HttpPost]
        public async virtual Task<ActionResult> CreateEdit(Subject model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == null)
                {
                    _sbjService.Add(model);
                }
                else
                {
                    await _sbjService.UpdateAsync(model);
                }

                return RedirectToAction("Index");
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

            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));
            if (sbj == null)
            {
                return HttpNotFound();
            }

            return View(sbj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public virtual async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _sbjService.RemoveByIdAsync(id);
            return RedirectToAction("Index");
        }

        public virtual async Task<ActionResult> Details(string id)
        {
            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));
            return View(sbj);
        }
    }
}