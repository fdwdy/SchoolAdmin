using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IPositionDbService
    {
        Task<IEnumerable<PositionDbStatistics>> GetAllWithEmployeesSorted();

        Task<PositionDbStatistics> GetByNameWithEmployeesSorted(string name);
    }
}
