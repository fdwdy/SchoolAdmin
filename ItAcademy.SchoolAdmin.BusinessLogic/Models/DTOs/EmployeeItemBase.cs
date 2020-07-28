using System.Collections.Generic;

namespace ItAcademy.SchoolAdmin.BusinessLogic.Models.DTOs
{
    public class EmployeeItemBase
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Middlename { get; set; }

        public string Email { get; set; }

        public ICollection<Phone> Phones { get; set; }
    }
}
