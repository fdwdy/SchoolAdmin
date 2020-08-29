using System;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Models.Identity;

namespace ItAcademy.SchoolAdmin.DataAccess.Interfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }

        IClientManager ClientManager { get; }

        ApplicationRoleManager RoleManager { get; }

        Task SaveAsync();
    }
}
