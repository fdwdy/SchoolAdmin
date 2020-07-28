using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface ISubjectDbService
    {
        Task<IEnumerable<SubjectDbStatistics>> GetAllWithEmployeesSorted();

        Task<SubjectDbStatistics> GetByNameWithEmployeesSorted(string name);
    }
}
