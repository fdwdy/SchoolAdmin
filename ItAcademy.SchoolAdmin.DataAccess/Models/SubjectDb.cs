using System.Collections;
using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class SubjectDb
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeDb> Employees { get; set; }
    }
}
