using System.Data.Entity;
using ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;
using ItAcademy.SchoolAdmin.DataAccess.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItAcademy.SchoolAdmin.DataAccess
{
    public class SchoolContext : IdentityDbContext<ApplicationUser>
    {
        public SchoolContext()
            : base("SchoolAdmin")
        {
            Database.SetInitializer<SchoolContext>(null);
        }

        public delegate void SaveChangesEventHandler(object sender, OnChangesSavedArgs e);

        public event SaveChangesEventHandler OnChangesSaved;

        public virtual DbSet<EmployeeDb> Employees { get; set; }

        public virtual DbSet<SubjectDb> Subjects { get; set; }

        public virtual DbSet<PositionDb> Positions { get; set; }

        public virtual DbSet<PhoneDb> Phones { get; set; }

        public virtual DbSet<MessageDb> Messages { get; set; }

        public virtual DbSet<ClientProfile> ClientProfiles { get; set; }

        public override int SaveChanges()
        {
            var result = base.SaveChanges();

            OnChangesSaved?.Invoke(this, new OnChangesSavedArgs(Employees));
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new PhoneConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
        }
    }
}
