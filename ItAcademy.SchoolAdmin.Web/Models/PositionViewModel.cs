using System.Web.Mvc;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class PositionViewModel
    {
        public string Id { get; set; }

        [Remote("CheckExistingPosition", "Position", HttpMethod = "POST", ErrorMessage = "Position already exists", AdditionalFields = "Id")]
        public string Name { get; set; }

        public short MaxEmployees { get; set; }
    }
}