using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models.DTOs
{
    public class SubjectDbStatistics
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeDbSubjectStatistics> Employees { get; set; }
    }
}
