using System;
using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.WebAPI.Models
{
    public class EmployeeModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string FullName => Name + ' ' + Surname + ' ' + Middlename;

        public IEnumerable<PhoneModel> Phones { get; set; }

        public IEnumerable<SubjectModel> Subjects { get; set; }

        public IEnumerable<PositionModel> Positions { get; set; }
    }
}