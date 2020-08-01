using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.WebAPI.Models
{
    public class PositionModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public short MaxEmployees { get; set; }

        public ICollection<EmployeePositionStatisticsModel> Employees { get; set; }

        public int Vacant { get; set; }
    }
}