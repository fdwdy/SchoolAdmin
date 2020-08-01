using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IMessageDbService
    {
        Result<MessageDb> Save(MessageDb msg);
    }
}
