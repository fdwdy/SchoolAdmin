using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class EmployeeListModel
    {
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Id { get; set; }

        public string ConvertedDate => BirthDate.ToString();

        public IEnumerable<string> Phones { get; set; }
    }
}
