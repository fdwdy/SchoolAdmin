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
        IEnumerable<EmployeeDTO> GetAll();

        Task<IEnumerable<EmployeeDTO>> GetAllAsync();

        Task<EmployeeDTO> GetByIdAsync(string id);

        Result Add(Employee emp);

        Task<Result<EmployeeDb>> AddAsync(EmployeeDb bookmark);

        Task RemoveByIdAsync(string id);

        Task<Result<EmployeeDb>> UpdateAsync(EmployeeDb course);

    }
}
