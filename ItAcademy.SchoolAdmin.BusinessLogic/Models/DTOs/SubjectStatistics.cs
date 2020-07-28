using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs
{
    public class SubjectStatistics
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeSubjectStatistics> Employees { get; set; }
    }
}
