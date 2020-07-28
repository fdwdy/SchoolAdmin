using ItAcademy.SchoolAdmin.Web.Enums;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class MessageViewModel
    {
        public string RecipientId { get; set; }

        public string Text { get; set; }

        public MessageTypeEnum Type { get; set; }
    }
}