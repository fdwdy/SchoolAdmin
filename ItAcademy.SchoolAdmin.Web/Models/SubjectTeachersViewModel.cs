using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class SubjectTeachersViewModel
    {
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }

        public IEnumerable<EmployeeSelectViewModel> Employees { get; set; }
    }
}