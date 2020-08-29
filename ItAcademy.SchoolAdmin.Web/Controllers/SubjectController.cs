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
    [Authorize]
    public partial class SubjectController : Controller
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
        public virtual async Task<ActionResult> GetSubjectData()
        {
            IEnumerable<Subject> sbj = await _sbjService.GetAllAsync();
            IEnumerable<SubjectViewModel> models = _mapper.Map<IEnumerable<SubjectViewModel>>(sbj);
            return PartialView(MVC.Subject.Views._SubjectData, models);
        }

        [HttpGet]
        public async virtual Task<ActionResult> Create()
        {
            SubjectViewModel model = new SubjectViewModel();
            return View(MVC.Subject.Views.CreateEdit, model);
        }

        [HttpGet]
        public async virtual Task<ActionResult> Edit(string id)
        {
            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));
            return View(MVC.Subject.Views.CreateEdit, sbj);
        }

        [HttpPost]
        public async virtual Task<ActionResult> CreateEdit(SubjectViewModel model)
        {
            var subj = _mapper.Map<Subject>(model);
            if (ModelState.IsValid)
            {
                if (subj.Id == null)
                {
                    _sbjService.Add(subj);
                }
                else
                {
                    await _sbjService.UpdateAsync(subj);
                }

                return RedirectToAction(MVC.Subject.Actions.Index());
            }

            return View();
        }

        [HttpGet]
        public virtual async Task<ActionResult> Search(string query)
        {
            IEnumerable<Subject> sbj = await _sbjService.SearchAsync(query);
            IEnumerable<SubjectViewModel> models = _mapper.Map<IEnumerable<SubjectViewModel>>(sbj);
            return Json(models, JsonRequestBehavior.AllowGet);
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
            return RedirectToAction(MVC.Subject.Actions.Index());
        }

        [HttpGet]
        public virtual async Task<ActionResult> Details(string id)
        {
            var sbj = _mapper.Map<SubjectViewModel>(await _sbjService.GetByIdAsync(id));
            return View(sbj);
        }

        [HttpPost]
        public virtual async Task<ActionResult> CheckExistingSubject(string name)
        {
            var subjectAlreadyExists = await IsSubjectExists(name);
            var result = Json(!subjectAlreadyExists, JsonRequestBehavior.AllowGet);
            return result;
        }

        private async Task<bool> IsSubjectExists(string name)
        {
            return await _sbjService.FindByName(name);
        }
    }
}