using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.WebAPI.Filters;
using ItAcademy.SchoolAdmin.WebAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ItAcademy.SchoolAdmin.WebAPI.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/subjects")]
    public class SubjectController : ApiController
    {
        private readonly ISubjectService _sbjService;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectService sbjService, IMapper mapper)
        {
            _sbjService = sbjService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Employees Sorted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Subjects don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Subjects found", typeof(SubjectModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetAll()
        {
            var subjects = await _sbjService.GetAllWithEmployeesSorted();
            var result = _mapper.Map<IEnumerable<SubjectStatistics>, IEnumerable<SubjectModel>>(subjects);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get All Employees Sorted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{name}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Subject don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Subject found", typeof(SubjectModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            var subject = await _sbjService.GetByNameWithEmployeesSorted(name);
            var result = _mapper.Map<SubjectStatistics, SubjectModel>(subject);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}
