using System.Data.Entity;
using ItAcademy.SchoolAdmin.DataAccess.EntitiesConfiguration;
using ItAcademy.SchoolAdmin.DataAccess.Models;

namespace ItAcademy.SchoolAdmin.DataAccess
{
    public class SchoolContext : DbContext
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

        public override int SaveChanges()
        {
            var result = base.SaveChanges();

            OnChangesSaved?.Invoke(this, new OnChangesSavedArgs(Employees));
            return result;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new PhoneConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
        }
    }
}
