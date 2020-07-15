using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IEmployeeDbService
    {
        Task<IEnumerable<EmployeeDb>> GetAllWithPhonesSubjectsAndPositionsSorted();
    }
}
