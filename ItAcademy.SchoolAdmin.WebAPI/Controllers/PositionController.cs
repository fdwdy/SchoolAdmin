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
    [RoutePrefix("api/positions")]
    public class PositionController : ApiController
    {
        private readonly IPositionService _posService;
        private readonly IMapper _mapper;

        public PositionController(IPositionService posService, IMapper mapper)
        {
            _posService = posService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get All Employees Sorted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Positions don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Positions found", typeof(PositionModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetAll()
        {
            var positions = await _posService.GetAllWithEmployeesSorted();
            var result = _mapper.Map<IEnumerable<PositionStatistics>, IEnumerable<PositionModel>>(positions);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        [HttpGet]
        [Route("{name}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Subject don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Subject found", typeof(PositionModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            var position = await _posService.GetByNameWithEmployeesSorted(name);
            var result = _mapper.Map<PositionStatistics, PositionModel>(position);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}
