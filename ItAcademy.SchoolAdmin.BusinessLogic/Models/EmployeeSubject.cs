namespace ItAcademy.SchoolAdmin.BusinessLogic.Models
{
    public class EmployeeSubject
    {
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public string SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
