using System;
using ItAcademy.SchoolAdmin.DataAccess.Enums;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class MessageDb
    {
        public string Id { get; set; }

        public string RecipientId { get; set; }

        public string Text { get; set; }

        public MessageTypeDb Type { get; set; }

        public DateTime Time { get; set; }

        public string Status { get; set; }
    }
}
