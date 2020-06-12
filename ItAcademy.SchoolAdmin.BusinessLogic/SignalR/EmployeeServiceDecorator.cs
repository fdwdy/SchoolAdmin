using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class EmployeeServiceDecorator : IEmployeeService
    {
        private readonly IMapper _mapper;

        private bool _disposedValue = false;

        private IEmployeeService _empService;

        private IUnitOfWork _uow;

        public EmployeeServiceDecorator(IEmployeeService empService, IUnitOfWork uow)
        {
            _empService = empService;
            _uow = uow;
            _uow.Db.OnChangesSaved += Db_OnChangesSaved;
        }

        public void Db_OnChangesSaved(object sender, DataAccess.OnChangesSavedArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<EmployeeHub>().Clients.All.broadcast(e.Employees);
        }

        public Result Add(Employee emp)
        {
            var result = _empService.Add(emp);
            return result;
        }

        public Task<EmployeeDTO> GetByIdAsync(string id)
        {
            var result = _empService.GetByIdAsync(id);
            return result;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _empService.GetAll();
        }

        public Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            return _empService.GetAllAsync();
        }

        public Task<Result<EmployeeDb>> AddAsync(EmployeeDb emp)
        {
            return _empService.AddAsync(emp);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _empService.RemoveByIdAsync(id);
        }

        public Task<Result<EmployeeDb>> UpdateAsync(EmployeeDb emp)
        {
            return _empService.UpdateAsync(emp);
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
                    _empService.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
