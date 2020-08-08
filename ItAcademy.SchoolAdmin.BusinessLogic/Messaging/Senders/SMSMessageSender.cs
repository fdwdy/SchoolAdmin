using Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Autofac;
using ItAcademy.SchoolAdmin.BusinessLogic.Interfaces;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;
using NLog;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging.Senders
{
    public class SMSMessageSender : IMessageSender, IMessageHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private IPhoneService _phService;

        public SMSMessageSender()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new PhoneServiceModule());
            var container = builder.Build();
            _phService = container.Resolve<IPhoneService>();
        }

        public bool IsProperContactAvailable(Employee emp)
        {
            return _phService.GetNumberById(emp.PrimaryPhoneId) == null ? false : true;
        }

        public Result<Message> Process(Message msg, Employee emp)
        {
            if (!IsProperContactAvailable(emp))
            {
                msg.Status = Enums.MessageStatus.Invalid;
                return Result<Message>.Fail(msg, "There is no contact available for this employee.");
            }

            try
            {
                return Send(msg, emp);
            }
            catch
            {
                msg.Status = Enums.MessageStatus.Error;
                return Result<Message>.Fail(msg, "Error occurred while sending message to employee: ");
            }
        }

        public Result<Message> Send(Message message, Employee emp)
        {
            Logger.Info($"Sending SMS to employee {emp.FullName}, " +
                $"phone number: {_phService.GetNumberById(emp.PrimaryPhoneId)}, " +
                $"Text: {message.Text}.");
            message.Status = Enums.MessageStatus.Ok;
            return Result<Message>.Ok(message);
        }
    }
}
