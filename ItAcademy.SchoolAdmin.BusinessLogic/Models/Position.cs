namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class Position
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Использовать ли ushort?.
        /// </summary>
        public short MaxEmployees { get; set; }
    }
}
