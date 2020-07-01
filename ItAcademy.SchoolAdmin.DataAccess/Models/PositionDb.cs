using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class PositionDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        /// Использовать ли ushort?.
        /// </summary>
        public short MaxEmployees { get; set; }

        public ICollection<EmployeeDb> Employees { get; set; }
    }
}
