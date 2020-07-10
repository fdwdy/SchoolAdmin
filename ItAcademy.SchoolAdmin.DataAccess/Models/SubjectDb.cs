using System.Collections.Generic;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class SubjectDb : IDbEntity
    {
        public SubjectDb()
        {
            Employees = new HashSet<EmployeeDb>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeDb> Employees { get; set; }
    }
}
