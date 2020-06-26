using System.Collections.Generic;
using System.Linq;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class SubjectViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<EmployeeSubject> EmployeeSubjects { get; set; }

        public List<Employee> Employees => EmployeeSubjects.Select(c => c.Employee).ToList();
    }
}