namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    using System;
    using System.Collections.Generic;

    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public ICollection<EmployeeSubject> EmployeeSubjects { get; set; }
    }
}
