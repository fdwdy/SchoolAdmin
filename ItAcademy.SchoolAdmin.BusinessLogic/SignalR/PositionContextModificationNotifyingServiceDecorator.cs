using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.DataAccess;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class PositionContextModificationNotifyingServiceDecorator : CommonServiceContextModificationNotifyingDecorator<Position, IPositionService>, IPositionService
    {
        public const string MethodName = "positionListModified";

        private readonly IMapper _mapper;

        private readonly IPositionService _posService;

        private bool _disposedValue = false;

        public PositionContextModificationNotifyingServiceDecorator(
            IPositionService posService,
            IMapper mapper,
            SchoolContext context,
            ISchoolHub hub)
            : base(posService, context, hub, MethodName)
        {
            _mapper = mapper;
            _posService = posService;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public async Task<bool> FindByName(string name)
        {
            return await _posService.FindByName(name);
        }

        public async Task<IEnumerable<PositionStatistics>> GetAllWithEmployeesSorted()
        {
            return await _posService.GetAllWithEmployeesSorted();
        }

        public async Task<PositionStatistics> GetByNameWithEmployeesSorted(string name)
        {
            return await _posService.GetByNameWithEmployeesSorted(name);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _posService.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
