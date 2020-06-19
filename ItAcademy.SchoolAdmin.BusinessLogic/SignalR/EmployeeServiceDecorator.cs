using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;
using Microsoft.AspNet.SignalR;

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
            _uow.Db.OnChangesSaved += OnChangesSaved;
        }

        public void OnChangesSaved(object sender, DataAccess.OnChangesSavedArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<EmployeeHub>().Clients.All.broadcast(e.Employees);
        }

        public Result Add(Employee emp)
        {
            var result = _empService.Add(emp);
            return result;
        }

        public Task<Employee> GetByIdAsync(string id)
        {
            var result = _empService.GetByIdAsync(id);
            return result;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _empService.GetAll();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            return _empService.GetAllAsync();
        }

        public Task<Result<EmployeeDb>> AddAsync(EmployeeDTO emp)
        {
            return _empService.AddAsync(emp);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _empService.RemoveByIdAsync(id);
        }

        public async Task UpdateAsync(Employee emp)
        {
            await _empService.UpdateAsync(emp);
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string query)
        {
            return await _empService.SearchAsync(query);
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
