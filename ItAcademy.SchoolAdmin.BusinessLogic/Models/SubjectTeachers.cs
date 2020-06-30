using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class SubjectTeachers
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public IEnumerable<string> EmployeeIds { get; set; }
    }
}
