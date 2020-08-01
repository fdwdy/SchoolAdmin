using System.Collections.Generic;
using ItAcademy.SchoolAdmin.BusinessLogic.Enums;
using ItAcademy.SchoolAdmin.BusinessLogic.Models;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class EmployeeContactsModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public MessageType MessageType { get; set; }

        public IEnumerable<Phone> Phones { get; set; }
    }
}