using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public class MessageSenderService : IMessageSenderService
    {
        private readonly MessageManager _msgHandler;

        public MessageSenderService(MessageManager msgHandler)
        {
            _msgHandler = msgHandler;
        }

        public Result<Message> SendMessageToEmployee(string message, Employee emp)
        {
            return _msgHandler.ProcessMessage(message, emp);
        }
    }
}
