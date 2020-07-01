using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Interfaces
{
    public interface IWorkerService
    {
        Task<Worker> GetWorkers(string positionId);

        Task SaveWorkers(string positionId, string[] employeeIds);
    }
}
