using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IWorkerDbService : ICommonManyToManyEditService<WorkerDb, string, string[]>
    {
    }
}
