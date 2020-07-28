using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models.DTOs
{
    public class PositionDbStatistics
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public short MaxEmployees { get; set; }

        public ICollection<EmployeeDbPositionStatistics> Employees { get; set; }
    }
}
