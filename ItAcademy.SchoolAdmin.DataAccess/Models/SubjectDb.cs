using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class SubjectDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeSubject> EmployeeSubjects { get; set; }
    }
}
