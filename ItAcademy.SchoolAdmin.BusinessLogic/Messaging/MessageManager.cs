using System;
using System.Collections.Generic;
using System.Linq;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging.SenderFactories;
using ItAcademy.SchoolAdmin.BusinessLogic.Messaging.Senders;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;
using ItAcademy.SchoolAdmin.Infrastructure;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Messaging
{
    public class MessageManager
    {
        private List<IMessageHandler> _handlers = new List<IMessageHandler>();
        private MessageSaver _msgSaver;

        public MessageManager(MessageSaver msgSaver)
        {
            _msgSaver = msgSaver;
        }

        public void AddHandler(IMessageHandler handler)
        {
            _handlers.Add(handler);
        }

        public IMessageSender ResolveSender(Employee emp)
        {
            return SenderFactory.GetSender(emp);
        }

        public void SetupHandlers(IMessageHandler sender)
        {
            AddHandler(sender);
            AddHandler(_msgSaver);
        }

        public Message PrepareMessage(string msg, Employee recipient)
        {
            return new Message
            {
                RecipientId = recipient.Id,
                Text = msg,
                Time = DateTime.Now,
                Type = recipient.MessageType,
            };
        }

        public Result<Message> ProcessMessage(string msg, Employee emp)
        {
            var sender = ResolveSender(emp);
            SetupHandlers((IMessageHandler)sender);
            var message = PrepareMessage(msg, emp);

            List<Result<Message>> resultList = new List<Result<Message>>();

            foreach (var handler in _handlers)
            {
                var result = handler.Process(message, emp);

                if (result.IsError && result.Data.Status == Enums.MessageStatus.Invalid)
                {
                    return result;
                }

                resultList.Add(result);
            }

            return resultList.First();
        }
    }
}
