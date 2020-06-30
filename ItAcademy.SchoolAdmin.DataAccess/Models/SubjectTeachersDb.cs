using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class SubjectTeachersDb
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public IEnumerable<string> EmployeeIds { get; set; }
    }
}
