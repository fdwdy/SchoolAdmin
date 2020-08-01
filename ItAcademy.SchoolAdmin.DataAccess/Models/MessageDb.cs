using System;
using ItAcademy.SchoolAdmin.DataAccess.Enums;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class MessageDb
    {
        public Guid Id { get; set; }

        public string RecipientId { get; set; }

        public string Text { get; set; }

        public MessageTypeDb Type { get; set; }

        public DateTime Time { get; set; }

        public MessageStatusDb Status { get; set; }
    }
}
