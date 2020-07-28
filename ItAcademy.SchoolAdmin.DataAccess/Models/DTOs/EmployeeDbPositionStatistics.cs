using System;
using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.DataAccess.Models.DTOs
{
    public class EmployeeDbPositionStatistics
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public ICollection<SubjectDb> Subjects { get; set; }

        public ICollection<PhoneDb> Phones { get; set; }
    }
}
