using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class Worker
    {
        public string PositionId { get; set; }

        public string PositionName { get; set; }

        public IEnumerable<string> EmployeeIds { get; set; }
    }
}
