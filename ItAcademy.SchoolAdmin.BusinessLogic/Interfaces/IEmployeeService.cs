using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IEmployeeService : ICommonService<Employee>, IDisposable
    {
        Task<IEnumerable<Employee>> GetAllWithPhonesSubjectsAndPositionsSorted();
    }
}
