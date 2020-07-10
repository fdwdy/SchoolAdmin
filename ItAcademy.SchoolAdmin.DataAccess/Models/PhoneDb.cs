namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class PhoneDb
    {
        public string Id { get; set; }

        public string Number { get; set; }

        public string EmployeeId { get; set; }

        public EmployeeDb Employee { get; set; }
    }
}
