using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class WorkerDb
    {
        public string PositionId { get; set; }

        public string PositionName { get; set; }

        public IEnumerable<string> EmployeeIds { get; set; }
    }
}
