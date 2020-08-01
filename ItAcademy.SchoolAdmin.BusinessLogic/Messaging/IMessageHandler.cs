using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public interface IMessageHandler
    {
        Result<Message> Process(Message message, Employee emp);
    }
}
