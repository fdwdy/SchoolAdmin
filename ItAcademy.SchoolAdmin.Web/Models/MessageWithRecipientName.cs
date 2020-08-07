using System;
using ItAcademy.SchoolAdmin.Web.Enums;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class MessageWithRecipient
    {
        public Guid Id { get; set; }

        public string RecipientId { get; set; }

        public string RecipientFullName { get; set; }

        public string Text { get; set; }

        public MessageTypeEnum Type { get; set; }

        public DateTime Time { get; set; }

        public MessageStatusEnum Status { get; set; }
    }
}