using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;

        private bool _disposedValue = false;

        private IUnitOfWork _uow;

        public SubjectService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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

        public Task<Result<Subject>> AddAsync(Subject sbj)
        {
            throw new System.NotImplementedException();
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

        public async Task SetEmployee(string id, List<Employee> emps)
        {
            var subject = await _uow.Subjects.GetByIdAsync(id);
            subject.EmployeeSubjects.Clear();
            foreach (var emp in emps)
            {
                DataAccess.Models.EmployeeSubject empsbj = new DataAccess.Models.EmployeeSubject
                {
                    EmployeeId = emp.Id,
                    SubjectId = subject.Id,
                };
                subject.EmployeeSubjects.Add(empsbj);
                    ////subject.EmployeeSubjects.Add(new DataAccess.Models.EmployeeSubject
                    ////{
                    ////    EmployeeId = emp.Id,
                    ////    SubjectId = subject.Id,
                    ////});
            }

            ////_uow.Subjects.Update(subject);
            _uow.Save();
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
