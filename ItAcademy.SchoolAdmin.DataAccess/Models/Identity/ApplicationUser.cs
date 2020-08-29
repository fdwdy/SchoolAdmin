using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.SchoolAdmin.DataAccess.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ClientProfile ClientProfile { get; set; }
    }
}
