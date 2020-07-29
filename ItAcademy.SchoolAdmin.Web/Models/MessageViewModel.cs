using System.Web.Mvc;
using ItAcademy.SchoolAdmin.Web.Enums;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class MessageViewModel
    {
        public string RecipientId { get; set; }

        [Remote("CheckMessageLength", "Employee", HttpMethod = "POST", ErrorMessage = "Message is too long", AdditionalFields = "Length")]
        public string Text { get; set; }

        public int Length { get; set; }

        public MessageTypeEnum Type { get; set; }
    }
}