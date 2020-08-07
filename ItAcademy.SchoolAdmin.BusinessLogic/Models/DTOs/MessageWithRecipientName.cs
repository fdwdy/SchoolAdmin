using System;
using ItAcademy.SchoolAdmin.BusinessLogic.Enums;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs
{
    public class MessageWithRecipientName
    {
        public Guid Id { get; set; }

        public string RecipientId { get; set; }

        public string RecipientFullName { get; set; }

        public string Text { get; set; }

        public MessageType Type { get; set; }

        public DateTime Time { get; set; }

        public MessageStatus Status { get; set; }
    }
}
