using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItAcademy.SchoolAdmin.WebAPI.Models
{
    public class EmployeePositionStatisticsModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Phones { get; set; }

        public IEnumerable<string> Subjects { get; set; }

    }
}