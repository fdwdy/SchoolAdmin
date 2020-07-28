using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.WebAPI.Models
{
    public class EmployeeSubjectStatisticsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Phones { get; set; }
    }
}