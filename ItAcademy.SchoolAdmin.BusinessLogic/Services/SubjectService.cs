using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;

        private readonly ISubjectDbService _sbjDbService;

        private bool _disposedValue = false;

        private IUnitOfWork _uow;

        public SubjectService(IUnitOfWork uow, IMapper mapper, ISubjectDbService sbjDbService)
        {
            _uow = uow;
            _mapper = mapper;
            _sbjDbService = sbjDbService;
        }

        public Result Add(Subject sbj)
        {
            _uow.Subjects.Create(_mapper.Map<Subject, SubjectDb>(sbj));
            return _uow.Subjects.Save();
        }

        public IEnumerable<Subject> GetAll()
        {
            var subjects = _uow.Subjects.GetAll();
            return _mapper.Map<IEnumerable<SubjectDb>, IEnumerable<Subject>>(subjects);
        }

        public async Task AddAsync(Subject sbj)
        {
            _uow.Subjects.Create(_mapper.Map<Subject, SubjectDb>(sbj));
            await _uow.SaveAsync();
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            var subjects = await _uow.Subjects.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDb>, IEnumerable<Subject>>(subjects);
        }

        public async Task<Subject> GetByIdAsync(string id)
        {
            var subject = await _uow.Subjects.GetByIdAsync(id);
            return _mapper.Map<SubjectDb, Subject>(subject);
        }

        public async Task RemoveByIdAsync(string id)
        {
            await _uow.Subjects.DeleteAsync(id);
            _uow.Subjects.Save();
        }

        public async Task UpdateAsync(Subject sbj)
        {
            var subject = _mapper.Map<Subject, SubjectDb>(sbj);
            await _uow.Subjects.UpdateAsync(subject);
            _uow.Subjects.Save();
        }

        public async Task<bool> FindByName(string name)
        {
            return await _uow.Subjects.FindByName(name);
        }

        public async Task<IEnumerable<Subject>> SearchAsync(string query)
        {
            var subjects = await _uow.Subjects.SearchAsync(query);
            return _mapper.Map<IEnumerable<SubjectDb>, IEnumerable<Subject>>(subjects);
        }

        public async Task<IEnumerable<SubjectStatistics>> GetAllWithEmployeesSorted()
        {
            var subjects = await _sbjDbService.GetAllWithEmployeesSorted();
            return _mapper.Map<IEnumerable<SubjectDbStatistics>, IEnumerable<SubjectStatistics>>(subjects);
        }

        public async Task<SubjectStatistics> GetByNameWithEmployeesSorted(string name)
        {
            var subject = await _sbjDbService.GetByNameWithEmployeesSorted(name);
            return _mapper.Map<SubjectDbStatistics, SubjectStatistics>(subject);
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
