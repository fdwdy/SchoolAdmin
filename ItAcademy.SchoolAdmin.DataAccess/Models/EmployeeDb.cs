using System;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class EmployeeDb
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
