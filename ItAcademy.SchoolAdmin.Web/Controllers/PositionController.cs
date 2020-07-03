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
    public partial class PositionController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPositionService _posService;

        public PositionController(IPositionService posService, IMapper mapper)
        {
            _posService = posService;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            IEnumerable<Position> positions = await _posService.GetAllAsync();
            IEnumerable<PositionViewModel> models = _mapper.Map<IEnumerable<PositionViewModel>>(positions);
            return View(models);
        }

        [HttpGet]
        public async virtual Task<ActionResult> Create()
        {
            PositionViewModel model = new PositionViewModel();
            return View(MVC.Position.Views.CreateEdit, model);
        }

        [HttpGet]
        public async virtual Task<ActionResult> Edit(string id)
        {
            var sbj = _mapper.Map<PositionViewModel>(await _posService.GetByIdAsync(id));
            return View(MVC.Position.Views.CreateEdit, sbj);
        }

        [HttpPost]
        public async virtual Task<ActionResult> CreateEdit(PositionViewModel model)
        {
            var pos = _mapper.Map<Position>(model);
            if (ModelState.IsValid)
            {
                if (pos.Id == null)
                {
                    await _posService.AddAsync(pos);
                }
                else
                {
                    await _posService.UpdateAsync(pos);
                }

                return RedirectToAction(MVC.Position.Actions.Index());
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

            var pos = _mapper.Map<PositionViewModel>(await _posService.GetByIdAsync(id));
            if (pos == null)
            {
                return HttpNotFound();
            }

            return View(pos);
        }

        [HttpPost]
        [ActionName("Delete")]
        public virtual async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _posService.RemoveByIdAsync(id);
            return RedirectToAction(MVC.Position.Actions.Index());
        }

        [HttpPost]
        public virtual async Task<ActionResult> CheckExistingPosition(PositionViewModel model)
        {
            if (model.Id != null)
            {
                var position = await _posService.GetByIdAsync(model.Id);
                return Json(position.Name == model.Name, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var positionAlreadyExists = await IsPositionExists(model.Name);
                return Json(!positionAlreadyExists, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public virtual async Task<ActionResult> Search(string query)
        {
            IEnumerable<Position> positions = await _posService.SearchAsync(query);
            IEnumerable<PositionViewModel> models = _mapper.Map<IEnumerable<PositionViewModel>>(positions);
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> IsPositionExists(string name)
        {
            return await _posService.FindByName(name);
        }
    }
}