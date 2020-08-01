using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public interface IMessageSenderService
    {
        Result<Message> SendMessageToEmployee(string message, Employee emp);
    }
}
