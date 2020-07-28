using System;
using ItAcademy.SchoolAdmin.BusinessLogic.Enums;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class Message
    {
        public string Id { get; set; }

        public string RecipientId { get; set; }

        public string Text { get; set; }

        public MessageType Type { get; set; }

        public DateTime Time { get; set; }

        public string Status { get; set; }
    }
}
