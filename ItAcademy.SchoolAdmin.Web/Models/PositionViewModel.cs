namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class PositionViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Использовать ли ushort?.
        /// </summary>
        public short MaxEmployees { get; set; }
    }
}