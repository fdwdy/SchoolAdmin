using ItAcademy.SchoolAdmin.BusinessLogic.Enums;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging.Senders;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging.SenderFactories
{
    public abstract class SenderFactory
    {
        public static IMessageSender GetSender(Employee emp)
        {
            if (emp.MessageType == MessageType.Email)
            {
                return new EmailMessageSender();
            }
            else
            {
                return new SMSMessageSender();
            }
        }
    }
}
