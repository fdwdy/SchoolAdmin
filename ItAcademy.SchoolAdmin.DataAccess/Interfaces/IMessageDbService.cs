using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IMessageDbService
    {
        Result<MessageDb> Save(MessageDb msg);

        Task<IEnumerable<MessageDbWithRecipientName>> GetAllSortedByStatusAndTimeAsync();

        Task<MessageDbWithRecipientName> GetByIdAsync(string id);
    }
}
