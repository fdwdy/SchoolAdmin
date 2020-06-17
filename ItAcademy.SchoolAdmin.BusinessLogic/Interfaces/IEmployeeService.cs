using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Mapping;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Result Add(Employee emp);

        IEnumerable<EmployeeDTO> GetAll();

        Task<Result<EmployeeDb>> AddAsync(EmployeeDTO emp);

        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(string id);

        Task RemoveByIdAsync(string id);

        Task UpdateAsync(Employee emp);

        Task<IEnumerable<Employee>> SearchAsync(string query);
    }
}
