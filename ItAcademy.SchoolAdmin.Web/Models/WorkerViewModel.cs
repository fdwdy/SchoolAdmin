using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class WorkerViewModel
    {
        public string PositionId { get; set; }

        public string PositionName { get; set; }

        public short MaxEmployees { get; set; }

        public IEnumerable<EmployeeSelectViewModel> Employees { get; set; }
    }
}