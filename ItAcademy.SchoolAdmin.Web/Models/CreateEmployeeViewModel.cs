using System;
using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        ////public string Phone { get; set; }

        public string FullName => $"{Name} {Surname} {Middlename}".Replace("  ", " ");

        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}