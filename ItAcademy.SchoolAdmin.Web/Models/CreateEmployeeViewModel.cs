﻿using System;
using System.Collections.Generic;
using ItAcademy.SchoolAdmin.Web.Enums;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public MessageTypeEnum MessageType { get; set; }

        public string FullName => $"{Name} {Surname} {Middlename}".Replace("  ", " ");

        public IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}