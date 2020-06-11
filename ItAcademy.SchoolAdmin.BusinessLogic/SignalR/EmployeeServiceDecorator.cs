using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.Infrastructure;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;

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

        private void Db_OnChangesSaved(object sender, DataAccess.OnChangesSavedArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<EmployeeHub>().Clients.All.Broadcast(e.Employees);
        }

        public Result Add(Employee emp)
        {
            var result = _empService.Add(emp);
            return result;
        }

        public IEnumerable<EmployeeDTO> GetAll()
        {
            return _empService.GetAll();
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
