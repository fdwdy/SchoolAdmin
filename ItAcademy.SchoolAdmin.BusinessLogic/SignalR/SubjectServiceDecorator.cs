using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.Infrastructure;
using Microsoft.AspNet.SignalR;

namespace ItAcademy.SchoolAdmin.BusinessLogic.SignalR
{
    public class SubjectServiceDecorator : ISubjectService
    {
        private readonly IMapper _mapper;

        private bool _disposedValue = false;

        private ISubjectService _sbjService;

        private IUnitOfWork _uow;

        public SubjectServiceDecorator(ISubjectService sbjService, IUnitOfWork uow)
        {
            _sbjService = sbjService;
            _uow = uow;
            _uow.Db.OnChangesSaved += OnChangesSaved;
        }

        public void OnChangesSaved(object sender, DataAccess.OnChangesSavedArgs e)
        {
            GlobalHost.ConnectionManager.GetHubContext<SubjectHub>().Clients.All.broadcast(e.Employees);
        }

        public Result Add(Subject sbj)
        {
            var result = _sbjService.Add(sbj);
            return result;
        }

        public async Task<Result<Subject>> AddAsync(Subject sbj)
        {
            return await _sbjService.AddAsync(sbj);
        }

        public Task<bool> FindByName(string name)
        {
            return _sbjService.FindByName(name);
        }

        public IEnumerable<Subject> GetAll()
        {
            return _sbjService.GetAll();
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _sbjService.GetAllAsync();
        }

        public async Task<Subject> GetByIdAsync(string id)
        {
            return await _sbjService.GetByIdAsync(id);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _sbjService.RemoveByIdAsync(id);
        }

        public async Task UpdateAsync(Subject emp)
        {
            await _sbjService.UpdateAsync(emp);
        }

        public Task<IEnumerable<Subject>> SearchAsync(string query)
        {
            return _sbjService.SearchAsync(query);
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
                    _sbjService.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
