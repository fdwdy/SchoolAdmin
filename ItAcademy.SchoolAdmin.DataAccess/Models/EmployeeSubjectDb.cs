namespace ItAcademy.SchoolAdmin.DataAccess.Models
{
    public class EmployeeSubjectDb
    {
        public string EmployeeId { get; set; }

        public EmployeeDb Employee { get; set; }

        public string SubjectId { get; set; }

        public SubjectDb Subject { get; set; }
    }
}
