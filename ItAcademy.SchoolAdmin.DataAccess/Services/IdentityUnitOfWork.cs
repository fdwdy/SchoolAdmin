using System;
using System.Threading.Tasks;
using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
        public class IdentityUnitOfWork : IIdentityUnitOfWork
        {
            private SchoolContext _db;

            private bool _disposed = false;

            public IdentityUnitOfWork(SchoolContext db)
            {
                _db = db;
                UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
                ClientManager = new ClientManager(db);
            }

            public ApplicationUserManager UserManager { get; }

            public IClientManager ClientManager { get; }

            public ApplicationRoleManager RoleManager { get; }

            public async Task SaveAsync()
            {
                await _db.SaveChangesAsync();
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            public virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        UserManager.Dispose();
                        RoleManager.Dispose();
                        ClientManager.Dispose();
                    }

                    _disposed = true;
                }
            }
        }
}
