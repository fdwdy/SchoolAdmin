using ItAcademy.SchoolAdmin.DataAccess.Interfaces;
using ItAcademy.SchoolAdmin.DataAccess.Models.Identity;

namespace ItAcademy.SchoolAdmin.DataAccess.Services
{
    public class ClientManager : IClientManager
    {
        public ClientManager(SchoolContext db)
        {
            Database = db;
        }

        public SchoolContext Database { get; set; }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
