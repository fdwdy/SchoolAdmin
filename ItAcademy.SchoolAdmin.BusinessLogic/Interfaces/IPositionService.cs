using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IPositionService : ICommonService<Position>, IDisposable
    {
        Task<bool> FindByName(string name);

        Task<IEnumerable<PositionStatistics>> GetAllWithEmployeesSorted();

        Task<PositionStatistics> GetByNameWithEmployeesSorted(string name);
    }
}
