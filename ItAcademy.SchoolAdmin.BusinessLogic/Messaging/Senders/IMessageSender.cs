using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging.Senders
{
    public interface IMessageSender
    {
        Result<Message> Send(Message message, Employee emp);

        bool IsProperContactAvailable(Employee emp);
    }
}
