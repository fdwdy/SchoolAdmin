using System.Collections.Generic;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public interface IMessageService
    {
        Result<Message> SendMessageToEmployee(string message, Employee emp);

        Task<IEnumerable<MessageWithRecipientName>> GetAllSortedByStatusAndTimeAsync();

        Task<MessageWithRecipientName> GetByIdAsync(string id);
    }
}
