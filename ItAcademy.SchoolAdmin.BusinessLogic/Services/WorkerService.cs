using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IMapper _mapper;

        private readonly IWorkerDbService _wrkService;

        public WorkerService(IWorkerDbService wrkService, IMapper mapper)
        {
            _mapper = mapper;
            _wrkService = wrkService;
        }

        public async Task<Worker> GetWorkers(string positionId)
        {
            return _mapper.Map<Worker>(await _wrkService.GetRelatedEntities(positionId));
        }

        public async Task SaveWorkers(string positionId, string[] employeeIds)
        {
            await _wrkService.SaveRelatedEntities(positionId, employeeIds);
        }
    }
}
