using System.Web.Mvc;

namespace ItAcademy.SchoolAdmin.Web.Models
{
    public class SubjectViewModel
    {
        public string Id { get; set; }

        [Remote("CheckExistingSubject", "Subject", HttpMethod = "POST", ErrorMessage = "Subject already exists")]
        public string Name { get; set; }
    }
}