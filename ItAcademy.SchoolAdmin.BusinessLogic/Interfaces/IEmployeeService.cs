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

        Result Add(Employee emp);

        Task<Result<EmployeeDb>> AddAsync(EmployeeDb bookmark);

        Task<Result<EmployeeDb>> RemoveByIdAsync(string id);

        Task<Result<EmployeeDb>> UpdateAsync(EmployeeDb course);

    }
}
