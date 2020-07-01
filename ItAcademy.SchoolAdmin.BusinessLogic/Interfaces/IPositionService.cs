using System;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IPositionService : ICommonService<Position>, IDisposable
    {
        Task<bool> FindByName(string name);
    }
}
