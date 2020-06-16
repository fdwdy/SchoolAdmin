using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class EmployeeListModel
    {
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string FullName { get; set; }

        public string Id { get; set; }
    }
}