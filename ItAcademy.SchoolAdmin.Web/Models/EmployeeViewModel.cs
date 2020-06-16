using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName { get => Name + ' ' + Surname + ' ' + Middlename; }
    }
}