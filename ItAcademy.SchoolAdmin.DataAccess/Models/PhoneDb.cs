using System.ComponentModel.DataAnnotations.Schema;

namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class PhoneDb
    {
        public string Id { get; set; }

        [Index("IX_PhoneNumbers_Phone_EmployeeId", 0, IsUnique = true)]
        public string Number { get; set; }

        [Index("IX_PhoneNumbers_Phone_EmployeeId", 1, IsUnique = true)]
        public string EmployeeId { get; set; }

        public EmployeeDb Employee { get; set; }
    }
}
