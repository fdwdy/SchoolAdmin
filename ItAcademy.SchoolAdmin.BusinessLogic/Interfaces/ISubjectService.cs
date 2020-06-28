using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface ISubjectService : IDisposable
    {
        Result Add(Subject sbj);

        IEnumerable<Subject> GetAll();

        Task<Result<Subject>> AddAsync(Subject sbj);

        Task<IEnumerable<Subject>> GetAllAsync();

        Task<Subject> GetByIdAsync(string id);

        Task RemoveByIdAsync(string id);

        Task UpdateAsync(Subject emp);

        Task SetEmployee(string id, List<Employee> emps);

        Task<IEnumerable<Subject>> SearchAsync(string query);

        Task<bool> FindByName(string name);
    }
}
