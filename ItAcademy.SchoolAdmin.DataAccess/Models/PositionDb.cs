using System.Collections.Generic;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class PositionDb : IDbEntity
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
