using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.WebAPI.Filters;
using ItAcademy.SchoolAdmin.WebAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace ItAcademy.SchoolAdmin.WebAPI.Controllers
{
    [BasicAuthentication]
    [RoutePrefix("api/employees")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _empService;

        public EmployeeController(IEmployeeService empService)
        {
            _empService = empService;
        }

        /// <summary>
        /// Get All Employees Sorted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Employees don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Employees found", typeof(EmployeeModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetAll()
        {
            var result = await _empService.GetAllWithPhonesSubjectsAndPositionsSorted();
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        /// <summary>
        /// Get All Employees Sorted
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Bad Request")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Employees don't exist")]
        [SwaggerResponse(HttpStatusCode.OK, "Employees found", typeof(EmployeeModel))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Something went wrong")]
        public async Task<IHttpActionResult> GetByName(string name)
        {
            var result = await _empService.GetByNameSorted(name);
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }
    }
}