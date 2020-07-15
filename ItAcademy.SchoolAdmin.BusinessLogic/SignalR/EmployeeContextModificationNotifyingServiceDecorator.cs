using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class EmployeeContextModificationNotifyingServiceDecorator : CommonServiceContextModificationNotifyingDecorator<Employee, IEmployeeService>, IEmployeeService
    {
        public const string MethodName = "employeeListModified";

        private readonly IMapper _mapper;

        private readonly IEmployeeService _empService;

        private bool _disposedValue = false;

        public EmployeeContextModificationNotifyingServiceDecorator(
            IEmployeeService empService,
            IMapper mapper,
            SchoolContext context,
            ISchoolHub hub)
            : base(empService, context, hub, MethodName)
        {
            _mapper = mapper;
            _empService = empService;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public Task<IEnumerable<Employee>> GetAllWithPhonesSubjectsAndPositionsSorted()
        {
            return _empService.GetAllWithPhonesSubjectsAndPositionsSorted();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _empService.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
