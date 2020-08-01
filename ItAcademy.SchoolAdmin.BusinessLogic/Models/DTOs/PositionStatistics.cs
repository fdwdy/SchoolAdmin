using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs
{
    public class PositionStatistics
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public short MaxEmployees { get; set; }

        public ICollection<EmployeePositionStatistics> Employees { get; set; }

        public int Vacant => MaxEmployees - Employees.Count;
    }
}
