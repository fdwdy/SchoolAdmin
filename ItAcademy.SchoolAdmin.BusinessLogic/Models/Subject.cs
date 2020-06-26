using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class Subject
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeSubject> EmployeeSubjects { get; set; }
    }
}
