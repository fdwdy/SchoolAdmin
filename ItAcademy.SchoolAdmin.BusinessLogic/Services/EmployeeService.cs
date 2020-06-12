namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
    using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
    using ItAcademy.SchoolAdmin.BusinessLogic.Models;
    using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
    using ItAcademy.SchoolAdmin.DataAccess.Models;
    using ItAcademy.SchoolAdmin.Infrastructure;

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;

        private bool _disposedValue = false;

        private IUnitOfWork _uow;

        public EmployeeService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public Result Add(Employee emp)
        {
            _uow.Employees.Create(_mapper.Map<Employee, EmployeeDb>(emp));
            return _uow.Employees.Save();
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            var employees = _uow.Employees.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employees = await _uow.Employees.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDb>, IEnumerable<EmployeeDTO>>(employees);
        }

        public Task<Result<EmployeeDb>> AddAsync(EmployeeDb bookmark)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result<EmployeeDb>> RemoveByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result<EmployeeDb>> UpdateAsync(EmployeeDb course)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _uow.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
