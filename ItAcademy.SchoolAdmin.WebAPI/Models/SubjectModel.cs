using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.WebAPI.Models
{
    public class SubjectModel
    {
        public string Name { get; set; }

        public IEnumerable<EmployeeSubjectStatisticsModel> Employees { get; set; }
    }
}