using System;
using System.Collections.Generic;
using ItAcademy.SchoolAdmin.DataAccess.Enums;
using ItAcademy.SchoolAdmin.DataAccess.Services;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class EmployeeDb : IDbEntity
    {
        public EmployeeDb()
        {
            Subjects = new HashSet<SubjectDb>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public MessageTypeDb MessageType { get; set; }

        public ICollection<SubjectDb> Subjects { get; set; }

        public ICollection<PositionDb> Positions { get; set; }

        public ICollection<PhoneDb> Phones { get; set; }
    }
}
