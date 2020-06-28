namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class EmployeeSelectViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Middlename { get; set; }

        public string Surname { get; set; }

        public string FullName => Name + ' ' + Surname + ' ' + Middlename;

        public bool IsSelected { get; set; }
    }
}