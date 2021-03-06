﻿using System;
using System.Collections.Generic;
using ItAcademy.SchoolAdmin.BusinessLogic.Enums;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class Employee
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public MessageType MessageType { get; set; }

        public string PrimaryPhoneId { get; set; }

        ////public virtual Phone PrimaryPhone { get; set; }

        public string FullName => Name + ' ' + Surname + ' ' + Middlename;

        public IEnumerable<Phone> Phones { get; set; }

        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<Position> Positions { get; set; }
    }
}
