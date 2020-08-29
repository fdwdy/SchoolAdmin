using Microsoft.AspNet.Identity;

namespace ItAcademy.SchoolAdmin.DataAccess.Models.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
        }
    }
}
